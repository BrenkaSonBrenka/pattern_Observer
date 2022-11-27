using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Publisher : IPub
    {
        int days = 30;

        public bool IsBroadcasting { get; set; }

        delegate void WeatherUpdate(double temp, double humidity, double press);

        event WeatherUpdate NotifyEvent;

        private Random random = new Random();

        private double Temperature { get; set; }
        private double Humidity { get; set; }
        private double Pressure { get; set; }

        public void AddSub(ISub sub)
        {
            NotifyEvent += sub.Update;
        }

        public void RemoveSub(ISub sub)
        {
            NotifyEvent -= sub.Update;
        }

        public async void Notify()
        {
            while (IsBroadcasting)
            {
                int sumTemp = 0;
                int sumHumidity = 0;
                int sumPress = 0;

                for (int i = 0; i < days; i++)
                {
                    sumTemp += random.Next(0, 31);
                    sumHumidity += random.Next(10, 80);
                    sumPress += random.Next(60, 110);
                }

                Temperature = sumTemp / days;
                Humidity = sumHumidity / days;
                Pressure = sumPress / days;

                NotifyEvent?.Invoke(Temperature, Humidity, Pressure);

                await Task.Delay(2000);
            }
        }
    }
}
