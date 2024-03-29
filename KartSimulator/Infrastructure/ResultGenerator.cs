﻿using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KartSimulator.Infrastructure
{
    /// <summary>
    /// The class that receives a raw file content and transforms it into a list of laps.
    /// </summary>
    public class ResultGenerator : IResultGenerator<Lap>
    {
        private readonly IFileReader _fileReader;
        public static string FileLocation { get; } = @"..\..\..\logs\log.txt";

        public ResultGenerator(IFileReader fileReader)
        {
            _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
        }

        /// <summary>
        /// Returns all laps.
        /// </summary>
        /// <returns></returns>
        public List<Lap> GetAllLaps()
        {
            return GetListFromFile();
        }

        /// <summary>
        /// Returns specific lap.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Lap FindLap(int id)
        {
            return GetListFromFile().First(x => x.Racer.RacerId == id);
        }

        private List<Lap> GetListFromFile()
        {
            var result = new List<Lap>();

            foreach (var line in _fileReader.GetLines(FileLocation))
            {
                var nextWhiteSpace = 0;
                var nextLetter = 0;
                nextWhiteSpace = FindNextWhiteSpace(nextLetter, line);
                var hour = line.Substring(0, nextWhiteSpace);
                nextLetter = FindNextLetterOrNumber(nextWhiteSpace, line);
                nextWhiteSpace = FindNextWhiteSpace(nextLetter, line);
                var racerId = line.Substring(nextLetter, nextWhiteSpace - nextLetter);
                nextLetter = FindNextLetterOrNumber(nextWhiteSpace, line);
                nextWhiteSpace = FindNextWhiteSpace(nextLetter, line);
                var racer = line.Substring(nextLetter, nextWhiteSpace - nextLetter);
                nextLetter = FindNextLetterOrNumber(nextWhiteSpace, line);
                nextWhiteSpace = FindNextWhiteSpace(nextLetter, line);
                var roundNumber = line.Substring(nextLetter, nextWhiteSpace - nextLetter);
                nextLetter = FindNextLetterOrNumber(nextWhiteSpace, line);
                nextWhiteSpace = FindNextWhiteSpace(nextLetter, line);
                var roundTime = line.Substring(nextLetter, nextWhiteSpace - nextLetter);
                nextLetter = FindNextLetterOrNumber(nextWhiteSpace, line);
                var averageSpeed = line.Substring(nextLetter, line.Length - nextLetter);
                result.Add(new Lap(hour, racerId, racer, roundNumber, roundTime, averageSpeed));
            }
            return result;
        }

        private static int FindNextWhiteSpace(int counter, string line)
        {
            while (line[counter] != ' ' && line[counter] != '\t')
            {
                counter++;
            }
            return counter;
        }

        private static int FindNextLetterOrNumber(int counter, string line)
        {
            while (!char.IsLetterOrDigit(line[counter]))
            {
                counter++;
            }
            return counter;
        }
    }
}