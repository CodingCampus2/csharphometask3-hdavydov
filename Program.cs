using System;
using CodingCampusCSharpHomework;

namespace HomeworkTemplate
{
    struct defStorage
    {
        public string name;
        public string address;
        public float lon;
        public float lat;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Func<Task3, string> TaskSolver = task =>
            {
                float UserLongitude = float.Parse(task.UserLongitude);
                float UserLatitude = float.Parse(task.UserLatitude);
                int placesAmount = task.DefibliratorStorages.Length;
                defStorage[] allStorageProperties = new defStorage[placesAmount];


                for (int i = 0; i < placesAmount; i++)
                {
                    string defibliratorStorage = task.DefibliratorStorages[i];

                    string[] defibrilatorStorageProperties = defibliratorStorage.Split(";");
                    defStorage properties;
                    properties.name = defibrilatorStorageProperties[0];
                    properties.address = defibrilatorStorageProperties[1];
                    properties.lon = float.Parse(defibrilatorStorageProperties[2]);
                    properties.lat = float.Parse(defibrilatorStorageProperties[3]);

                    allStorageProperties[i] = properties;
                }

                int closestIndex = 0;
                float minDistance = -1;

                for (int i = 0; i < placesAmount; i++)
                {
                    defStorage properties = allStorageProperties[i];
                    float x = (properties.lon - UserLongitude) * (float)Math.Cos((properties.lat + UserLatitude) / 2);
                    float y = properties.lat - UserLatitude;
                    float distance = (float)Math.Sqrt(x * x + y * y) * 6371;
                    if (minDistance < 0 || distance < minDistance)
                    {
                        minDistance = distance;
                        closestIndex = i;
                    }
                }

                return $"Name: {allStorageProperties[closestIndex].name}; Address: {allStorageProperties[closestIndex].address}";
            };

            Task3.CheckSolver(TaskSolver);
        }
    }
}
