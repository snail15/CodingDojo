using System;
using System.Collections.Generic;
using System.Linq;

namespace dojodachi {

    public class Dachi {

        public int happiness { get; set; }
        public int fullness { get; set; }
        public int energy { get; set; }
        public int meal { get; set; }
        public Random random = new Random();
        public int failure = 1;

        public Dachi() {
            happiness = 20;
            fullness = 20;
            energy = 50;
            meal = 3;
        }

        public void Feed() {
            if(failure == random.Next(0,4)){
                this.meal -= 1;
            } else {
                int gain = random.Next(5, 11);
                this.fullness += gain;
                this.meal -= 1;
            }
        }

        public void Play() {
            if(failure == random.Next(0,4)){
                this.energy -= 5;
            } else {
                int gain = random.Next(5, 11);
                this.happiness += gain;
                this.energy -= 5;
            }
        }

        public void Work() {
            int gain = random.Next(1, 4);
            this.energy -= 5;
            this.meal += gain;
        }

        public void Sleep() {
            this.energy += 15;
            this.fullness -= 5;
            this.happiness -= 5;
        }

        public bool CheckWin(){
            if(this.fullness > 100 && this.energy > 100 && this.happiness >100) {
                return true;
            } 
            return false;
        }

        public bool CheckLose() {
            if(this.fullness <= 0 || this.happiness <= 0) {
                return true;
            }
            return false;
        }

    }
}
