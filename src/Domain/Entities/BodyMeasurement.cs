using System;
using Domain.Common;
using Domain.Errors;
using Domain.Exceptions;
using Domain.Extensions;

namespace Domain.Entities
{
    public class BodyMeasurement : AuditableEntity
    {
        public Guid AccountId {get; protected set;}
        public DateTime Date {get; protected set;}
        public string Description {get; protected set;}
        public float Weight {get; protected set;}
        public int Height {get; protected set;}
        public float Arm {get; protected set;}
        public float Chest {get; protected set;}
        public float Waist {get; protected set;}
        public float Hip {get; protected set;}
        public float Thigh {get; protected set;}
        public float Calf {get; protected set;}
        protected BodyMeasurement(){}
        public BodyMeasurement(Guid id,Guid accountId ,string description, DateTime date,float weight, int height, float arm,float chest,
                        float waist, float hip, float thigh, float calf) : base(id)
        {
            SetAccountId(accountId);
            SetDescription(description);
            SetDate(date);
            SetWeight(weight);
            SetHeight(height);
            SetArm(arm);
            SetChest(chest);
            SetWaist(waist);
            SetHip(hip);
            SetThigh(thigh);
            SetCalf(calf);
            FirstAudit();
        }
        private void SetAccountId(Guid accountId)
        => _= accountId == Guid.Empty ? throw new InvalidIdException("Account id must not be empty.") : AccountId = accountId;
        public void SetDate(DateTime date)
        {
            date = date.FormatToYearMonthDay();
            if(Date == date) return;
            Date = date;

            Update();
        } 
        public void SetDescription(string description)
        {
            if(string.IsNullOrWhiteSpace(description))
            {
                description = "";
            } 
            
            if(Description == description)  return;
            
            Description = description;
            Update();
        }
            
        public void SetWeight(float weight)
        {
            if(weight.IsEquelsOrBelowZero())
            {
                throw new InvalidMeasurementValueException(DomainErrorCodes.BodyMeasurement.InvalidWeight, "Weight must be greater than zero.");
            }

            if(Weight == weight) return;

            Weight = weight;
            Update();
        }

        public void SetHeight(int height)
        {
            if(height.IsEquelsOrBelowZero())
            {
                throw new InvalidMeasurementValueException(DomainErrorCodes.BodyMeasurement.InvalidHeight, "Height must be greater than zero.");
            }

            if(Height == height) return;

            Height = height;
            Update();
        }

        public void SetArm(float arm)
        {
            if(arm.IsEquelsOrBelowZero())
            {
                throw new InvalidMeasurementValueException(DomainErrorCodes.BodyMeasurement.InvalidArm, "Arm must be greater than zero.");
            }

            if(Arm == arm) return;

            Arm = arm;
            Update();
        }


        public void SetChest(float chest)
        {
            if(chest.IsEquelsOrBelowZero())
            {
                throw new InvalidMeasurementValueException(DomainErrorCodes.BodyMeasurement.InvalidChest, "Chest must be greater than zero.");
            }

            if(Chest == chest) return;

            Chest = chest;
            Update();
        }

        public void SetWaist(float waist)
        {
            if(waist.IsEquelsOrBelowZero())
            {
                throw new InvalidMeasurementValueException(DomainErrorCodes.BodyMeasurement.InvalidWaist, "Waist must be greater than zero.");
            }

            if(Waist == waist) return;

            Waist = waist;
            Update();
        }
        public void SetHip(float hip)
        {
            if(hip.IsEquelsOrBelowZero())
            {
                throw new InvalidMeasurementValueException(DomainErrorCodes.BodyMeasurement.InvalidHip, "Hip must be greater than zero.");
            }

            if(Hip == hip) return;

            Hip = hip;
            Update();
        }

        public void SetThigh(float thigh)
        {
            if(thigh.IsEquelsOrBelowZero())
            {
                throw new InvalidMeasurementValueException(DomainErrorCodes.BodyMeasurement.InvalidThigh, "Thigh must be greater than zero.");
            }

            if(Thigh == thigh) return;

            Thigh = thigh;
            Update();
        }

        public void SetCalf(float calf)
        {
            if(calf.IsEquelsOrBelowZero())
            {
                throw new InvalidMeasurementValueException(DomainErrorCodes.BodyMeasurement.InvalidCalf, "Calf must be greater than zero.");
            }

            if(Calf == calf) return;

            Calf = calf;
            Update();
        }
    }
}