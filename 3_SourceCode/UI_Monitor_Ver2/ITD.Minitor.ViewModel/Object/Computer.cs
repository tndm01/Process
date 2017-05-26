using System.Collections.Generic;

namespace ITD.Minitor.ViewModel.Object
{
    public class Computer
    {
        public string Cum { get; set; }
        public string Tram { get; set; }
        public string MaMT { get; set; }
        public string IP { get; set; }
        public string ThoiGian { get; set; }
        public string TrangThai { get; set; }
        public List<string> ThietBi { get; set; }
        public List<string> MucDoThietBi { get; set; }
    }
}