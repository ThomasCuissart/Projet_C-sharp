﻿using System.Collections.Generic;


        public class Name
        {
            public string en { get; set; }
            public string fr { get; set; }

        }
        public class Genus
        {
            public string en { get; set; }
            public string fr { get; set; }

        }
        public class Description
        {
            public string en { get; set; }
            public string fr { get; set; }

        }
        public class Stats
        {
            public string name { get; set; }
            public int stat { get; set; }

        }
        public class Pokemon
        {
            public int id { get; set; }
            public Name name { get; set; }
            public IList<string> types { get; set; }
            public int height { get; set; }
            public int weight { get; set; }
            public Genus genus { get; set; }
            public Description description { get; set; }
            public IList<Stats> stats { get; set; }
            public int lastEdit { get; set; }

        }
