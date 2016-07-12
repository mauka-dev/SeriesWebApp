using System;
using System.Collections.Generic;

namespace SeriesWebApp.BusinessLayer
{
    public class ComplexSeries
    {
        public ComplexSeries() { }

        /// <summary>
        /// Generates Sequence numbers
        /// </summary>
        /// <param name="repeatingSeqNo">Repeats 1 in sequence with this many number of times</param>
        /// <param name="maxSeriesTerm">generates sequences until this number of iterations</param>
        /// <returns></returns>
        public List<int> GenerateSeries(int maxSeriesTerm, int repeatingSeqNo = 3)
        {
            List<int> seriesList = new List<int>();
            try
            {
                for (int term = 0; term < maxSeriesTerm; term++) //Iterate  until this incrementing term value to create series elements.
                {
                    for (int repeatingSeqNoCounter = 0; repeatingSeqNoCounter < repeatingSeqNo && seriesList.Count < maxSeriesTerm; repeatingSeqNoCounter++) //Iterate until this incrementing repeatingSeqNo value to store sums in series collection
                    {
                        if (term == repeatingSeqNoCounter)
                        {
                            seriesList.Add(1);
                            term++;
                        }
                        else
                        {
                            int lastSeriesIndex = seriesList.Count; //find last element in series collection
                            int sumValue = 0;
                            for (int seriesIndex = lastSeriesIndex - 1, currentSeqCounter = 0; currentSeqCounter < repeatingSeqNo; seriesIndex--, currentSeqCounter++) //reverse iterate until decrementing repeatingSeqNo value
                            {
                                sumValue += seriesList[seriesIndex]; //addup the sums of last 3 values (i.e repeatingSeqNo value)                           
                            }
                            seriesList.Add(sumValue);                    //insert in series collection this summed value as new value in collection                           
                        }
                    }
                }
            }
            catch (ArgumentOutOfRangeException orx)
            {
                throw orx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return seriesList;
        }

        /// <summary>
        /// Find required number from Nth position within generated sequence that is fully divisible by Divisor
        /// </summary>
        /// <param name="divisor">Divisor </param>
        /// <param name="nIndex">Nth postion within generated sequence that is fully divisible by Divisor</param>
        /// <returns></returns>
        public int FindSeriesElement(int maxSeriesTerm, int divisor, int nIndex)
        {
            if (divisor < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (divisor == 0)
            {
                throw new DivideByZeroException();
            }

            List<int> dividendList = new List<int>();
            int result = 0;
            try
            {
                List<int> seriesList = GenerateSeries(maxSeriesTerm); //generate series elements taking N as Series term              

                for (int i = 0; i < seriesList.Count; i++)
                {
                    if (seriesList[i] % divisor == 0)
                    {
                        dividendList.Add(seriesList[i]);
                    }
                }
                result = dividendList[nIndex - 1];
            }
            catch (ArgumentOutOfRangeException orx)
            {
                //handle it,if required
                throw orx;
            }
            catch (DivideByZeroException ze)
            {
                //handle it,if required
                throw ze;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;   //resultant element
        }
    }
}
