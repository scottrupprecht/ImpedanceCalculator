using System.Data;
using NPoco;

namespace Domain
{
        [TableName("SPEAKER_INFO")]
        [PrimaryKey("SPEAKER_ID")]
    public class SpeakerInfo
    {
        [Column("SPEAKER_ID")]
        public int SpeakerId { get; set; }

        [Column("BRAND")]
        public string Brand { get; set; }

        [Column("MODEL")]
        public string Model { get; set; }

        [Column("IMPEDANCE")]
        public int Impedance { get; set; }
    }


}
