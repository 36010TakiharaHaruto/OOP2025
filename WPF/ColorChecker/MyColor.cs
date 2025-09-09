using System.Windows.Media;

namespace ColorChecker {
    public struct MyColor {
        public Color Color { get; set; }  
        public string Name { get; set; }
        public override string ToString() {
            if (Name == "Custom" || string.IsNullOrEmpty(Name))
                return $"R:{Color.R}, G:{Color.G}, B:{Color.B}";
            else
                return Name;
        }
    }
}
