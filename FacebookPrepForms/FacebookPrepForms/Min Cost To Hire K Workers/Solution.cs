using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Min_Cost_To_Hire_K_Workers
{
    public static class Solution
    {

        /*Rule 1
         * offer[x]   quality[x]  
         * -------  = ---------
         * offer[y]   quality[y] 
         * 
         * Rule 2
         * offer[x] >= wage[x]
         * 
         * 
         * at least one worker will be paid his expcted wage(captain)
         * offer[captain] = wage[captain] 
         * 
         * offer[i]         quality[i]
         * --------      =  ---------------
         * offer[captain]   quality[captain]
         * 
         * with substitue we get
         * 
         * offer[i]         quality[i]
         * -------          ---------
         * wage[captain]    quality[captain]
         * 
         * isolate offer[i] so we get
         * 
         *              quality[i] * wage[captain]
         * offer[i] =   --------------------------
         *              quality[captain]
         *              
         * example
         * name || quality || expected wage || offered wage
         * jay       10             80              80  --> captain
         * tom       5              35              5 * 8 = 40
         * ben       15             30              15*8 = 120
         *              
         * now we pick the two lowest which are tom and jay  which there wage is  80 +40 = 120
         * 
         * 
         * name || quality || expected wage || offered wage
         * jay       10             80              10 * 7 = 70 < 80 --> not allowed to be hired
         * tom       5              35              35 --> captain
         * ben       15             30              15 * 7  = 105
         *      
         * now we pick the two lowest which are tom and ben  which there wage is  35 +105 = 140    
         * 
         * 
         * name || quality || expected wage || offered wage
         * jay       10             80              10*2 = 20 < 80 ---> now allowed to be hired
         * tom       5              35              5*2 = 10 < 35 --> not allowed to be hired
         * ben       15             30              30 --> captain
         * 
         * we cannot pick two so ben cannot be captain
         * 
         * 
         * so we choose the lowest between 140(tom captain) and 120 (jay captain) which is 120 ofc
         */

        public static double MinCostToHireWorkers(int[] quality, int[] wage, int k)
        {
            Double minCoast = double.MaxValue; ;

            if (quality != null && quality.Length > 0 && wage != null && wage.Length > 0)
            {

                var workers = new List<(double ratio, int quality)>();
                for (int i = 0; i < wage.Length; i++)
                {
                    double ratio = (double)wage[i] / quality[i];
                    workers.Add((ratio, quality[i]));
                }
                var orderedWorkers = workers.OrderBy(x => x.ratio);

                for (int captain = k - 1; captain < wage.Length; captain++)
                {
                    double captainRatio = orderedWorkers.ElementAt(captain).ratio;
                    List<double> acceptedOffers = new List<double>();
                    for (int worker = 0; worker < captain + 1; worker++)
                    {
                        double offer = orderedWorkers.ElementAt(worker).quality * captainRatio;
                        acceptedOffers.Add(offer);
                    }

                    var maxHeap = new MaxHeap<double>();
                    double sumHeap = 0;
                    for (int i = 0; i < k; i++)
                    {
                        maxHeap.Add(acceptedOffers[i]);
                        sumHeap += acceptedOffers[i];
                    }

                    for (int i = k; i < acceptedOffers.Count; i++)
                    {
                        if (maxHeap.Count() != 0 && acceptedOffers[i] < maxHeap.ExtractMax())
                        {
                            sumHeap -= maxHeap.ExtractMax();// .top
                            //maxHeap.pop
                            //maxheap.push(acceptedOffers[i]);
                            sumHeap += acceptedOffers[i];
                        }
                    }
                    double cost = sumHeap;
                    minCoast = Math.Min(minCoast, cost);

                }
            }

            return minCoast;
        }
    }
}
