using StargateAPI.Business.Data;

namespace StargateAPI.Business.Dtos
{
    public class PersonAstronaut
    {
        public PersonAstronaut() { }
        public PersonAstronaut(Person person, AstronautDetail? astronautDetail) : this()
        {

            PersonId = person.Id;
            Name = person.Name;
            if(astronautDetail != null)
            {
                CurrentRank = astronautDetail.CurrentRank;
                CurrentDutyTitle = astronautDetail.CurrentDutyTitle;
                CareerEndDate = astronautDetail.CareerEndDate;
                CareerStartDate = astronautDetail.CareerStartDate;
            }
        }

        public int PersonId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string CurrentRank { get; set; } = string.Empty;

        public string CurrentDutyTitle { get; set; } = string.Empty;

        public DateTime? CareerStartDate { get; set; }

        public DateTime? CareerEndDate { get; set; }


    }
}
