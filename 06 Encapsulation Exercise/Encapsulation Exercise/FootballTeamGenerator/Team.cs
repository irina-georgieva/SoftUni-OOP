﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value; 
            }
        }

        public double Rating
            => this.players.Count == 0 
            ? 0 
            : Math.Round(players.Average(x => x.Stats));

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = this.players.FirstOrDefault
                (x => x.Name == playerName);
            if (player == null)
            {
                throw new InvalidOperationException($"Player {playerName} is not in " +
                    $"{this.Name} team.");
            }

            this.players.Remove(player);            
        }
    }
}
