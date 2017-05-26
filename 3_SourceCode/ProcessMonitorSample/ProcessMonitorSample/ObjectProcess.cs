using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMonitorSample
{
    public class ObjectProcess
    {
        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _CPU;

        public string CPU
        {
            get { return _CPU; }
            set { _CPU = value; }
        }
        private string _ram;

        public string Ram
        {
            get { return _ram; }
            set { _ram = value; }
        }
        private string _des;

        public string Des
        {
            get { return _des; }
            set { _des = value; }
        }
        private string _status;

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
