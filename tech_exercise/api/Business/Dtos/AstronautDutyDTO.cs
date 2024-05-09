using StargateAPI.Business.Data;
using System;

namespace StargateAPI.Business.Dtos
{
    public class AstronautDutyDTO
    {
        public AstronautDutyDTO() { }
        public AstronautDutyDTO(AstronautDuty duty) : this()
        {
            Id = duty.Id;
            PersonId = duty.Id;
            Rank = duty.Rank;
            DutyTitle = duty.DutyTitle;
            DutyStartDate = duty.DutyStartDate;
            DutyEndDate = duty.DutyEndDate;
        }

        public int Id { get; set; }

        public int PersonId { get; set; }

        public string Rank { get; set; } = string.Empty;

        public string DutyTitle { get; set; } = string.Empty;

        public DateTime DutyStartDate { get; set; }

        public DateTime? DutyEndDate { get; set; }
    }
}