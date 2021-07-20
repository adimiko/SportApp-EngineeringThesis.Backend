using System;
using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public class WorkoutsAnalysis
    {
        public double VolumePercent {get; protected set;}
        public double NumberOfCompletedWorkoutsPercent {get; protected set;}
        public double DurationPercent  {get; protected set;}

        public WorkoutsAnalysis(WorkoutsStats firstWorkoutsStats, WorkoutsStats secoundWorkoutsStats)
        {
            SetVolumePercent(firstWorkoutsStats.Volume, secoundWorkoutsStats.Volume);
            SetNumberOfCompletedWorkoutsPercent(firstWorkoutsStats.NumberOfCompletedWorkouts, secoundWorkoutsStats.NumberOfCompletedWorkouts);
            SetDurationPercent(firstWorkoutsStats.Duration, secoundWorkoutsStats.Duration);
        }

        private void SetVolumePercent(double? firstVolume, double? secondVolume)
            => VolumePercent = CalculatePercent(firstVolume, secondVolume);

        private void SetNumberOfCompletedWorkoutsPercent(int? firstNumberOfCompletedWorkouts, int? secondNumberOfCompletedWorkouts)
            => NumberOfCompletedWorkoutsPercent = CalculatePercent(firstNumberOfCompletedWorkouts, secondNumberOfCompletedWorkouts);

        private void SetDurationPercent(int? firstDuration, int? secondDuration)
            => DurationPercent = CalculatePercent(firstDuration, secondDuration);

        private double CalculatePercent(int? firsValue, int? secondValue)
        {
            if(!firsValue.HasValue || !secondValue.HasValue || firsValue == 0 || secondValue == 0)
            {
                throw new NotEnoughDataException("Not enough data to perform the analysis.");
            }

            var percent = (((double)secondValue/(double)firsValue) * 100d) - 100d;

            return Math.Round(percent, 2);
        }

        private double CalculatePercent(double? firsValue, double? secondValue)
        {
            if(!firsValue.HasValue || !secondValue.HasValue || firsValue == 0 || secondValue == 0)
            {
                throw new NotEnoughDataException("Not enough data to perform the analysis.");
            }

            var percent = (((double)secondValue/(double)firsValue) * 100d) - 100d;

            return Math.Round(percent, 2);
        }
    }
}