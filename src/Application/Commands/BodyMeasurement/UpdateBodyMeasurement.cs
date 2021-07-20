using System;

namespace Application.Commands.BodyMeasurement
{
    public class UpdateBodyMeasurement : ICommand
    {
        public Guid Id {get; set;}
        public Guid AccountId {get; set;}
        public DateTime Date {get; set;}
        public string Description {get; set;}
        public float Weight {get; set;}
        public int Height {get; set;}
        public float Arm {get; set;}
        public float Chest {get; set;}
        public float Waist {get; set;}
        public float Hip {get;  set;}
        public float Thigh {get; set;}
        public float Calf {get; set;}


    }
}