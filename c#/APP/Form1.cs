using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using IronPython;
using IronPython.Hosting;
using IronPython.Runtime;
using IronPython.Modules;


namespace APP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            init();
        }
        public void init()
        {
            var engine = IronPython.Hosting.Python.CreateEngine();
            var scope = engine.CreateScope();
            try
            {
                var source = engine.CreateScriptSourceFromFile("test.py");
                source.Execute(scope);
                Console.WriteLine("checked");
                var test = scope.GetVariable<Func<object,object,object>>("sum");
                var a = test(3,4);
                Console.WriteLine(a.ToString(),a.GetType());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                
        }
    }
}
