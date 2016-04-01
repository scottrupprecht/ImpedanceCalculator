using Domain;
using NPoco;
using System.Collections.Generic;

namespace DataAccess
{
    public class SpeakerDao
    {
        #region select

        public List<SpeakerInfo> GetAllSpeakers()
        {
            using (IDatabase db = new Database("ScottColeImp"))
            {
                return db.Fetch<SpeakerInfo>(
                    @"SELECT
                        SI.SPEAKER_ID,
                        SI.BRAND,
                        SI.MODEL,
                        SI.IMPEDANCE
                        FROM SPEAKER_INFO SI");
            }
        }

        public SpeakerInfo GetSpeakerById(int id)
        {
            using (IDatabase db = new Database("ScottColeImp"))
            {
                return db.SingleOrDefault<SpeakerInfo>(
                    @"SELECT
                        SI.SPEAKER_ID,
                        SI.BRAND,
                        SI.MODEL,
                        SI.IMPEDANCE
                        FROM SPEAKER_INFO SI
                        WHERE SI.SPEAKER_ID = @0", id);
            }
        }

        #endregion select

        public void InsertSpeaker(SpeakerInfo speakerInfo)
        {
            using (IDatabase db = new Database("ScottColeImp"))
            {
                db.Insert("SPEAKER_INFO", "SPEAKER_ID", true, speakerInfo);
            }
        }
    }
}