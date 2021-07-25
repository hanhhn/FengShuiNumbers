using System.Collections.Generic;

namespace FengShui.Service.Dtos
{
    public class FengShuiNumberConfiguration
    {
        public int PhoneLength { get; set; }
        public Network Networks { get; set; }
        public string[] EndwithInvalid { get; set; }
        public string[] EndWithValid { get; set; }
        public Fraction[] TotalMatch { get; set; }
    }

    public class Network
    {
        public string[] Viettel { get; set; }
        public string[] Mobi { get; set; }
        public string[] VinaPhone { get; set; }

        public List<string> Pattern
        {
            get
            {
                var pattern = new List<string>();
                pattern.AddRange(Viettel);
                pattern.AddRange(Mobi);
                pattern.AddRange(VinaPhone);
                return pattern;
            }
        }
    }

    public class Fraction
    {
        public double N { get; set; }
        public double D { get; set; }
    }
}
