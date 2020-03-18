/*
Copyright 2017 James Craig

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using Mirage.Generators.BaseClasses;
using Mirage.Interfaces;

namespace Mirage.Generators
{
    /// <summary>
    /// FemaleFirstName Generator
    /// </summary>
    /// <seealso cref="StringGeneratorBase"/>
    public sealed class FemaleFirstNameAttribute : StringGeneratorBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FemaleFirstNameAttribute()
            : base("", "")
        {
        }

        private static readonly string[] FemaleFirstNames = { "Sophia", "Isabella", "Emma", "Olivia", "Ava", "Emily",
                                                "Abigail", "Madison", "Mia", "Chloe", "Elizabeth",
                                                "Ella", "Addison", "Natalie", "Lily", "Grace", "Samantha"
                                                , "Avery", "Sofia", "Aubrey", "Brooklyn", "Lillian",
                                                "Victoria", "Evelyn", "Hannah", "Alexis", "Charlotte",
                                                "Zoey", "Leah", "Amelia", "Zoe", "Hailey", "Layla",
                                                "Gabriella", "Nevaeh", "Kaylee", "Alyssa", "Anna", "Sarah",
                                                "Allison", "Savannah", "Ashley", "Audrey", "Taylor",
                                                "Brianna", "Aaliyah", "Riley", "Camila", "Khloe", "Claire",
                                                "Sophie", "Arianna", "Peyton", "Harper", "Alexa", "Makayla",
                                                "Julia", "Kylie", "Kayla", "Bella", "Katherine", "Lauren",
                                                "Gianna", "Maya", "Sydney", "Serenity", "Kimberly", "Mackenzie",
                                                "Autumn", "Jocelyn", "Faith", "Lucy", "Stella", "Jasmine",
                                                "Morgan", "Alexandra", "Trinity", "Molly", "Madelyn",
                                                "Scarlett", "Andrea", "Genesis", "Eva", "Ariana", "Madeline",
                                                "Brooke", "Caroline", "Bailey", "Melanie", "Kennedy",
                                                "Destiny", "Maria", "Naomi", "London", "Payton", "Lydia",
                                                "Ellie", "Mariah", "Aubree", "Kaitlyn", "Violet", "Rylee",
                                                "Lilly", "Angelina", "Katelyn", "Mya", "Paige", "Natalia",
                                                "Ruby", "Piper", "Annabelle", "Mary", "Jade", "Isabelle",
                                                "Liliana", "Nicole", "Rachel", "Vanessa", "Gabrielle", "Jessica",
                                                "Jordyn", "Reagan", "Kendall", "Sadie", "Valeria", "Brielle",
                                                "Lyla", "Isabel", "Brooklynn", "Reese", "Sara", "Adriana",
                                                "Aliyah", "Jennifer", "Mckenzie", "Gracie", "Nora", "Kylee",
                                                "Makenzie", "Izabella", "Laila", "Alice", "Amy", "Michelle",
                                                "Skylar", "Stephanie", "Juliana", "Rebecca", "Jayla", "Eleanor",
                                                "Clara", "Giselle", "Valentina", "Vivian", "Alaina", "Eliana",
                                                "Aria", "Valerie", "Haley", "Elena", "Catherine", "Elise", "Lila",
                                                "Megan", "Gabriela", "Daisy", "Jada", "Daniela", "Penelope",
                                                "Jenna", "Ashlyn", "Delilah", "Summer", "Mila", "Kate", "Keira",
                                                "Adrianna", "Hadley", "Julianna", "Maci", "Eden", "Josephine",
                                                "Aurora", "Melissa", "Hayden", "Alana", "Margaret", "Quinn",
                                                "Angela", "Brynn", "Alivia", "Katie", "Ryleigh", "Kinley",
                                                "Paisley", "Jordan", "Aniyah", "Allie", "Miranda", "Jacquelin",
                                                "Melody", "Willow", "Diana", "Cora", "Alexandria", "Mikayla",
                                                "Danielle", "Londyn", "Addyson", "Amaya", "Hazel", "Callie",
                                                "Teagan", "Adalyn", "Ximena", "Angel", "Kinsley", "Shelby",
                                                "Makenna", "Ariel", "Jillian", "Chelsea", "Alayna", "Harmony",
                                                "Sienna", "Amanda", "Presley", "Maggie", "Tessa", "Leila", "Hope",
                                                "Genevieve", "Erin", "Briana", "Delaney", "Esther", "Kathryn",
                                                "Ana", "Mckenna", "Camille", "Cecilia", "Lucia", "Lola", "Leilani",
                                                "Leslie", "Ashlynn", "Kayleigh", "Alondra", "Alison", "Haylee",
        "Emma","Olivia","Ava","Isabella","Sophia","Mia","Charlotte","Amelia","Evelyn","Abigail","Harper","Emily",
            "Elizabeth","Avery","Sofia","Ella","Madison","Scarlett","Victoria","Aria","Grace","Chloe","Camila","Penelope",
            "Riley","Layla","Lillian","Nora","Zoey","Mila","Aubrey","Hannah","Lily","Addison","Eleanor","Natalie","Luna",
            "Savannah","Brooklyn","Leah","Zoe","Stella","Hazel","Ellie","Paisley","Audrey","Skylar","Violet","Claire","Bella",
            "Aurora","Lucy","Anna","Samantha","Caroline","Genesis","Aaliyah","Kennedy","Kinsley","Allison","Maya","Sarah",
            "Madelyn","Adeline","Alexa","Ariana","Elena","Gabriella","Naomi","Alice","Sadie","Hailey","Eva","Emilia","Autumn",
            "Quinn","Nevaeh","Piper","Ruby","Serenity","Willow","Everly","Cora","Kaylee","Lydia","Aubree","Arianna","Eliana",
            "Peyton","Melanie","Gianna","Isabelle","Julia","Valentina","Nova","Clara","Vivian","Reagan","Mackenzie","Madeline",
            "Brielle","Delilah","Isla","Rylee","Katherine","Sophie","Josephine","Ivy","Liliana","Jade","Maria","Taylor","Hadley",
            "Kylie","Emery","Adalynn","Natalia","Annabelle","Faith","Alexandra","Ximena","Ashley","Brianna","Raelynn","Bailey",
            "Mary","Athena","Andrea","Leilani","Jasmine","Lyla","Margaret","Alyssa","Adalyn","Arya","Norah","Khloe","Kayla","Eden",
            "Eliza","Rose","Ariel","Melody","Alexis","Isabel","Sydney","Juliana","Lauren","Iris","Emerson","London","Morgan",
            "Lilly","Charlie","Aliyah","Valeria","Arabella","Sara","Finley","Trinity","Ryleigh","Jordyn","Jocelyn","Kimberly",
            "Esther","Molly","Valerie","Cecilia","Anastasia","Daisy","Reese","Laila","Mya","Amy","Teagan","Amaya","Elise","Harmony",
            "Paige","Adaline","Fiona","Alaina","Nicole","Genevieve","Lucia","Alina","Mckenzie","Callie","Payton","Eloise",
            "Brooke","Londyn","Mariah","Julianna","Rachel","Daniela","Gracie","Catherine","Angelina","Presley","Josie","Harley",
            "Adelyn","Vanessa","Makayla","Parker","Juliette","Amara","Marley","Lila","Ana","Rowan","Alana","Michelle","Malia",
            "Rebecca","Brooklynn","Brynlee","Summer","Sloane","Leila","Sienna","Adriana","Sawyer","Kendall","Juliet","Destiny",
            "Alayna","Elliana","Diana","Hayden","Ayla","Dakota","Angela","Noelle","Rosalie","Joanna","Jayla","Alivia","Lola",
            "Emersyn","Georgia","Selena","June","Daleyza","Tessa","Maggie","Jessica","Remi","Delaney","Camille","Vivienne","Hope",
            "Mckenna","Gemma","Olive","Alexandria","Blakely","Izabella","Catalina","Raegan","Journee","Gabrielle","Lucille","Ruth",
            "Amiyah","Evangeline","Blake","Thea","Amina","Giselle","Lilah","Melissa","River","Kate","Adelaide","Charlee","Vera",
            "Leia","Gabriela","Zara","Jane","Journey","Elaina","Miriam","Briella","Stephanie","Cali","Ember","Lilliana","Aniyah",
            "Logan","Kamila","Brynn","Ariella","Makenzie","Annie","Mariana","Kali","Haven","Elsie","Nyla","Paris","Lena","Freya",
            "Adelynn","Lyric","Camilla","Sage","Jennifer","Paislee","Talia","Alessandra","Juniper","Fatima","Raelyn","Amira",
            "Arielle","Phoebe","Kinley","Ada","Nina","Ariah","Samara","Myla","Brinley","Cassidy","Maci","Aspen","Allie","Keira",
            "Kaia","Makenna","Amanda","Heaven","Joy","Lia","Madilyn","Gracelyn","Laura","Evelynn","Lexi","Haley","Miranda","Kaitlyn",
            "Daniella","Felicity","Jacqueline","Evie","Angel","Danielle","Ainsley","Dylan","Kiara","Millie","Jordan","Maddison",
            "Rylie","Alicia","Maeve","Margot","Kylee","Phoenix","Heidi","Zuri","Alondra","Lana","Madeleine","Gracelynn","Kenzie",
            "Miracle","Shelby","Elle","Adrianna","Bianca","Addilyn","Kira","Veronica","Gwendolyn","Esmeralda","Chelsea","Alison",
            "Skyler","Magnolia","Daphne","Jenna","Everleigh","Kyla","Braelynn","Harlow","Annalise","Mikayla","Dahlia","Maliyah",
            "Averie","Scarlet","Kayleigh","Luciana","Kelsey","Nadia","Amber","Gia","Kamryn","Yaretzi","Carmen","Jimena","Erin",
            "Christina","Katie","Ryan","Viviana","Alexia","Anaya","Serena","Katelyn","Ophelia","Regina","Helen","Remington","Camryn",
            "Cadence","Royalty","Amari","Kathryn","Skye","Emely","Jada","Ariyah","Aylin","Saylor","Kendra","Cheyenne","Fernanda",
            "Sabrina","Francesca","Eve","Mckinley","Frances","Sarai","Carolina","Kennedi","Nylah","Tatum","Alani","Lennon","Raven",
            "Zariah","Leslie","Winter","Abby","Mabel","Sierra","April","Willa","Carly","Jolene","Rosemary","Aviana","Madelynn",
            "Selah","Renata","Lorelei","Briana","Celeste","Wren","Charleigh","Leighton","Annabella","Jayleen","Braelyn","Ashlyn",
            "Jazlyn","Mira","Oakley","Malaysia","Edith","Avianna","Maryam","Emmalyn","Hattie","Kensley","Macie","Bristol","Marlee",
            "Demi","Cataleya","Maia","Sylvia","Itzel","Allyson","Lilith","Melany","Kaydence","Holly","Nayeli","Meredith","Nia",
            "Liana","Megan","Justice","Bethany","Alejandra","Janelle","Elisa","Adelina","Ashlynn","Elianna","Aleah","Myra","Lainey",
            "Blair","Kassidy","Charley","Virginia","Kara","Helena","Sasha","Julie","Michaela","Carter","Matilda","Kehlani","Henley",
            "Maisie","Hallie","Jazmin","Priscilla","Marilyn","Cecelia","Danna","Colette","Baylee","Elliott","Ivanna","Cameron",
            "Celine","Alayah","Hanna","Imani","Angelica","Emelia","Kalani","Alanna","Lorelai","Macy","Karina","Addyson","Aleena",
            "Aisha","Johanna","Mallory","Leona","Mariam","Kynlee","Madilynn","Karen","Karla","Skyla","Beatrice","Dayana","Gloria",
            "Milani","Savanna","Karsyn","Rory","Giuliana","Lauryn","Liberty","Galilea","Aubrie","Charli","Kyleigh","Brylee","Jillian",
            "Anne","Haylee","Dallas","Azalea","Jayda","Tiffany","Avah","Shiloh","Bailee","Jazmine","Esme","Coraline","Madisyn",
            "Elaine","Lilian","Kyra","Kaliyah","Kora","Octavia","Irene","Kelly","Lacey","Laurel","Adley","Anika","Janiyah","Dorothy",
            "Sutton","Julieta","Kimber","Remy","Cassandra","Rebekah","Collins","Elliot","Emmy","Sloan","Hayley","Amalia","Jemma",
            "Jamie","Melina","Leyla","Jaylah","Anahi","Jaliyah","Kailani","Harlee","Wynter","Saige","Alessia","Monica","Anya",
            "Antonella","Emberly","Khaleesi","Ivory","Greta","Maren","Alena","Emory","Alaia","Cynthia","Addisyn","Alia","Lylah",
            "Angie","Ariya","Alma","Crystal","Jayde","Aileen","Kinslee","Siena","Zelda","Katalina","Marie","Pearl","Reyna","Mae",
            "Zahra","Kailey","Jessie","Tiana","Amirah","Madalyn","Alaya","Lilyana","Julissa","Armani","Lennox","Lillie","Jolie","Laney",
            "Roselyn","Mara","Joelle","Rosa","Kaylani","Bridget","Liv","Oaklyn","Aurelia","Clarissa","Elyse","Marissa","Monroe","Kori",
            "Elsa","Rosie","Amelie","Aitana","Aliza","Eileen","Poppy","Emmie","Braylee","Milana","Addilynn","Royal","Chaya","Frida",
            "Bonnie","Amora","Stevie","Tatiana","Malaya","Mina","Emerie","Reign","Zaylee","Annika","Kenia","Linda","Kenna","Faye",
            "Reina","Brittany","Marina","Astrid","Kadence","Mikaela","Jaelyn","Briar","Kaylie","Teresa","Bria","Hadassah","Lilianna",
            "Guadalupe","Rayna","Chanel","Lyra","Noa","Zariyah","Laylah","Aubrielle","Aniya","Livia","Ellen","Meadow","Amiya","Ellis",
            "Elora","Milan","Hunter","Princess","Leanna","Nathalie","Clementine","Nola","Tenley","Simone","Lina","Marianna","Martha",
            "Sariah","Louisa","Noemi","Emmeline","Kenley","Belen","Erika","Myah","Lara","Amani","Ansley","Everlee","Maleah","Salma",
            "Jaelynn","Kiera","Dulce","Nala","Natasha","Averi","Mercy","Penny","Ariadne","Deborah","Elisabeth","Zaria","Hana","Kairi",
            "Yareli","Raina","Ryann","Lexie","Thalia","Karter","Annabel","Christine","Estella","Keyla","Adele","Aya","Estelle","Landry",
            "Tori","Perla","Lailah","Miah","Rylan","Angelique","Avalynn","Romina","Ari","Jaycee","Jaylene","Kai","Louise","Mavis",
            "Scarlette","Belle","Lea","Nalani","Rivka","Ayleen","Calliope","Dalary","Zaniyah","Kaelyn","Sky","Jewel","Joselyn","Madalynn",
            "Paola","Giovanna","Isabela","Karlee","Aubriella","Azariah","Tinley","Dream","Claudia","Corinne","Erica","Milena","Aliana",
            "Kallie","Alyson","Joyce","Tinsley","Whitney","Emilee","Paisleigh","Carolyn","Jaylee","Zoie","Frankie","Andi","Judith",
            "Paula","Xiomara","Aiyana","Amia","Analia","Audrina","Hadlee","Rayne","Amayah","Cara","Celia","Lyanna","Opal","Amaris",
            "Clare","Gwen","Giana","Veda","Alisha","Davina","Rhea","Sariyah","Noor","Danica","Kathleen","Lillianna","Lindsey",
            "Maxine","Paulina","Hailee","Harleigh","Nancy","Jessa","Raquel","Raylee","Zainab","Chana","Lisa","Heavenly","Oaklynn",
            "Aminah","Emmalynn","Patricia","India","Janessa","Paloma","Ramona","Sandra","Abril","Emmaline","Itzayana","Kassandra",
            "Vienna","Marleigh","Kailyn","Novalee","Rosalyn","Hadleigh","Luella","Taliyah","Avalyn","Barbara","Iliana","Jana",
            "Meilani","Aadhya","Alannah","Blaire","Brenda","Casey","Selene","Lizbeth","Adrienne","Annalee","Malani","Aliya","Miley",
            "Nataly","Bexley","Joslyn","Maliah","Zion","Breanna","Melania","Estrella","Ingrid","Jayden","Kaya","Kaylin","Harmoni",
            "Arely","Jazlynn","Kiana","Dana","Mylah","Oaklee","Ailani","Kailee","Legacy","Marjorie","Paityn","Courtney","Ellianna",
            "Jurnee","Karlie","Evalyn","Holland","Kenya","Magdalena","Carla","Halle","Aryanna","Kaiya","Kimora","Naya","Saoirse",
            "Susan","Desiree","Ensley","Renee","Esperanza","Treasure","Caylee","Ellison","Kristina","Adilynn","Anabelle","Egypt",
            "Spencer","Tegan","Aranza","Vada","Emerald","Florence","Marlowe","Micah","Sonia","Sunny","Tara","Riya","Yara","Alisa",
            "Nathalia","Yamileth","Saanvi","Samira","Sylvie","Brenna","Carlee","Jenny","Miya","Monserrat","Zendaya","Alora"};

        /// <summary>
        /// Gets a value indicating whether this <see cref="IGenerator"/> is a default one.
        /// </summary>
        /// <value><c>true</c> if default; otherwise, <c>false</c>.</value>
        public override bool Default => false;

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public override string Next(Random rand)
        {
            return rand.Next(FemaleFirstNames);
        }
    }
}