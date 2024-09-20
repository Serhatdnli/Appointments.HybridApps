

namespace Appointments.HybridApps.Components.Pages
{
    public partial class Counter
    {
        private int[] incrementValues = new int[]
        {
            1,
            5,
            10
        };
        private int incrementIndex = 0;

        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount += incrementValues[incrementIndex % incrementValues.Length];

            if (currentCount >= 30)
            {
                currentCount = 0;
                incrementIndex++;
            }

        }
    }


}
