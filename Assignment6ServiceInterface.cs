using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Assignment6Services
{
    [ServiceContract]
    public interface IAssignment6Service
    {

        // Here we need a few services
        // the serves will be: weather app, newsfocus app, temperature conversion service, currency conversion service, sorting service.
        
        // gets the five day weather forecast for a given zip code
        [OperationContract]
        string[] Weather5Day(int zipCode);

        // Gets the news for a string array of topics
        [OperationContract]
        string[] NewsFocus(string[] topics);


        // Converts a temperature based on the string that you give it
        // example: conversionString = "c2f" converts celcius to farenheit
        // example: conversionString = "f2c" converts fahrenheit to celsius
        [OperationContract]
        int tempConverter(int temp, string conversionString);

        // Sorts a string based on a given sorting algorithm
        // The two supported are bubble sort, heapsort and insertion sort
        [OperationContract]
        int[] sortingService(int[] nums, string algorithm);


        // Converts some money to a valid conversion string
        // immediatley returns -1 if the conversionstring is invalid
        [OperationContract]
        int currentConversionService(int money, string conversionString);
    }

}
