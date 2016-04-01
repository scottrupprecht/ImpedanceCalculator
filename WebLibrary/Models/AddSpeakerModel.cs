using Domain;

namespace WebLibrary.Models
{
    public class AddSpeakerModel
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int Impedance { get; set; }

        public SpeakerInfo ToDomain()
        {
            return new SpeakerInfo
            {
                Brand = Brand,
                Model = Model,
                Impedance = Impedance
            };
        }
    }
}