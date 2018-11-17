using System;
using System.Collections.Generic;
using System.Linq;
using CoreMotion;
using Foundation;
using HealthKit;
using UIKit;

namespace AiFamily.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");

        }

        public void StartTimer(TimeSpan interval, Func<bool> callback)
        {
            NSTimer timer = NSTimer.CreateRepeatingTimer(interval, t =>
            {
                if (!callback())
                    t.Invalidate();
            });
            NSRunLoop.Main.AddTimer(timer, NSRunLoopMode.Common);
        }


        public void GetSteps()
        {
            var healthKitStore = new HKHealthStore();
            var stepRateType = HKQuantityType.Create(HKQuantityTypeIdentifier.StepCount);
            var sort = new NSSortDescriptor(HKSample.SortIdentifierStartDate, true);
            var q = new HKSampleQuery(stepRateType, HKQuery.GetPredicateForSamples(NSDate.Now.AddSeconds(TimeSpan.FromDays(-365).TotalSeconds), NSDate.Now.AddSeconds(TimeSpan.FromDays(1).TotalSeconds), HKQueryOptions.None), 0, new NSSortDescriptor[] { },
                new HKSampleQueryResultsHandler((HKSampleQuery query2, HKSample[] results, NSError error2) =>
                {
                    var query = results; //property created within the model to expose later.
                }));
            healthKitStore.ExecuteQuery(q);
        }

    }
}
