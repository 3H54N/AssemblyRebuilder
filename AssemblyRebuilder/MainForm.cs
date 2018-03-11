using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using dnlib.DotNet;

namespace AssemblyRebuilder
{
    internal partial class MainForm : Form
    {
        private static readonly string ProgramName = Assembly.GetExecutingAssembly().GetName().Name;

        public string AssemblyPath { get; set; }

        public ModuleDef ManifestModule { get; set; }

        public IManagedEntryPoint ManagedEntryPoint { get; set; }

        public ModuleKind ManifestModuleKind { get; set; }

        public MainForm()
        {
            InitializeComponent();
            Text = $"{Application.ProductName} v{Application.ProductVersion}";
            for (int i = 0; i < 4; i++)
                cmbManifestModuleKind.Items.Add((ModuleKind)i);
        }

        public MainForm(string assemblyPath) : this()
        {
            AssemblyPath = Path.GetFullPath(assemblyPath);
            LoadAssembly();
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e) => e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            tbAssemblyPath.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            LoadAssembly();
        }

        private void btOpenAssembly_Click(object sender, EventArgs e)
        {
            if (odlgSelectAssembly.ShowDialog() == DialogResult.OK)
                tbAssemblyPath.Text = odlgSelectAssembly.FileName;
            else
                return;
            LoadAssembly();
        }

        private void tbAssemblyPath_TextChanged(object sender, EventArgs e) => AssemblyPath = tbAssemblyPath.Text;

        private void chkNoStaticConstructor_CheckedChanged(object sender, EventArgs e) => LoadAllEntryPoints();

        private void cmbEntryPoint_SelectedIndexChanged(object sender, EventArgs e) => ManagedEntryPoint = ((IManagedEntryPointWrapper)cmbEntryPoint.SelectedItem).ManagedEntryPoint;

        private void cmbManifestModuleKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isExecutable;

            ManifestModuleKind = (ModuleKind)cmbManifestModuleKind.SelectedItem;
            isExecutable = MustHasManagedEntryPoint();
            cmbEntryPoint.Enabled = isExecutable;
            chkNoStaticConstructor.Enabled = isExecutable;
            if (isExecutable)
                LoadAllEntryPoints();
            else
                cmbEntryPoint.Items.Clear();
        }

        private void btRebuild_Click(object sender, EventArgs e) => Rebuild();

        private void LoadAssembly()
        {
            try
            {
                ManifestModule = ModuleDefMD.Load(AssemblyPath);
                chkNoStaticConstructor.Enabled = true;
                cmbManifestModuleKind.Enabled = true;
                btRebuild.Enabled = true;
            }
            catch
            {
                MessageBox.Show("无效程序集，请重新选定路径", ProgramName);
                ManifestModule = null;
                cmbEntryPoint.Enabled = false;
                chkNoStaticConstructor.Enabled = false;
                cmbManifestModuleKind.Enabled = false;
                btRebuild.Enabled = false;
                return;
            }
            LoadManifestModuleKind();
            LoadAllEntryPoints();
        }

        private void LoadAllEntryPoints()
        {
            MethodSig methodSig;

            cmbEntryPoint.Items.Clear();
            foreach (TypeDef typeDef in ManifestModule.GetTypes())
                foreach (MethodDef methodDef in typeDef.Methods)
                {
                    if (!methodDef.IsStatic)
                        continue;
                    if (methodDef.IsGetter || methodDef.IsSetter)
                        continue;
                    if (chkNoStaticConstructor.Checked && methodDef.IsStaticConstructor)
                        continue;
                    methodSig = (MethodSig)methodDef.Signature;
                    switch (methodSig.Params.Count)
                    {
                        case 0:
                            break;
                        case 1:
                            if (methodSig.Params[0].FullName == "System.String[]")
                                break;
                            else
                                continue;
                        default:
                            continue;
                    }
                    switch (methodSig.RetType.FullName)
                    {
                        case "System.Void":
                        case "System.Int32":
                            break;
                        default:
                            continue;
                    }
                    cmbEntryPoint.Items.Add(new IManagedEntryPointWrapper(methodDef));
                }
            ManagedEntryPoint = ManifestModule.ManagedEntryPoint;
            if (ManagedEntryPoint != null)
                for (int i = 0; i < cmbEntryPoint.Items.Count; i++)
                    if (((IManagedEntryPointWrapper)cmbEntryPoint.Items[i]).ManagedEntryPoint.MDToken.Raw == ManagedEntryPoint.MDToken.Raw)
                        cmbEntryPoint.SelectedIndex = i;
        }

        private void LoadManifestModuleKind()
        {
            ManifestModuleKind = ManifestModule.Kind;
            cmbManifestModuleKind.SelectedItem = ManifestModuleKind;
        }

        private bool MustHasManagedEntryPoint() => ManifestModuleKind != ModuleKind.Dll && ManifestModuleKind != ModuleKind.NetModule;

        private void Rebuild()
        {
            if (MustHasManagedEntryPoint() && ManagedEntryPoint == null && MessageBox.Show("未选择入口点，是否重建？", ProgramName, MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            string extension;
            string newAssemblyPath;

            extension = Path.GetExtension(AssemblyPath);
            newAssemblyPath = AssemblyPath.Substring(0, AssemblyPath.Length - extension.Length);
            newAssemblyPath = $"{newAssemblyPath}_Rebuilded{extension}";
            ManifestModule.ManagedEntryPoint = ManagedEntryPoint;
            ManifestModule.Kind = ManifestModuleKind;
            ManifestModule.Write(newAssemblyPath);
            MessageBox.Show("重建成功", ProgramName);
        }
    }
}
