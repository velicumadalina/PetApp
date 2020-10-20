//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using WebApi_PetApp.Models;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Api_PetApp.Controllers
//{
//    public class AnimalsController : ControllerBase
//    {
//        List<Animal> animals = new List<Animal>();

//        public AnimalsController()
//        {
//            animals.Add(new Animal
//            {
//                Id = 1,
//                ShelterId = "a",
//                Name = "Elliot",
//                Image = "https://www.strayrescue.org/media/k2/items/cache/elliot-4130-L.jpg",
//                Breed = "Mixed",
//                Gender = "Male",
//                Characteristics = "shy",
//                EnergyLevel = "High",
//                Age = "Junior",
//                Size = "small",
//                Type = "Cat",
//                Hair = "short",
//                Description = "Elliot is a fun loving guy who enjoys playing with toys and getting cuddles.",
//                FriendlyWithDogs = true,
//                FriendlyWithCats = true,
//                FriendlyWithKids = true,
//                SpecialNeeds = false
//            });
//            animals.Add(new Animal
//            {
//                Id = 2,
//                ShelterId = "a",
//                Name = "Luna",
//                Image = "https://www.strayrescue.org/media/k2/items/cache/luna-stt-4111-L.jpg",
//                Breed = "Pitbull",
//                Gender = "Female",
//                Characteristics = "protective",
//                EnergyLevel = "High",
//                Age = "Adult",
//                Size = "medium",
//                Type = "Dog",
//                Hair = "short",
//                Description = "She loves toys, watching the world out the window, and playing with other dogs.  She would do well with an energetic playmate (whether it is human or k9).",
//                FriendlyWithDogs = true,
//                FriendlyWithCats = false,
//                FriendlyWithKids = true,
//                SpecialNeeds = false
//            });
//            //animals.Add(new Animal
//            //{
//            //    Id = 3,
//            //    ShelterId = "a",
//            //    Name = "Azula",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/azula-4128-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Female",
//            //    Characteristics = new string[] { "very", "1 year" },
//            //    EnergyLevel = "Low",
//            //    Age = "Adult",
//            //    Size = "small",
//            //    Type = "Cat",
//            //    Hair = "long",
//            //    Description = "Azula is a quirky petite tabby. She is looking for her forever person who ideally is looking for their ride or die chick. Azula loves to give neck hugs and snuggle. She is so content being held that she purrs while being carried around. She likes to look out the window and watch the birds at the bird feeder. Azula likes to play with her feather stick and on the ripple rug. She would do best as a solo cat so she can get all of the cuddles. ",
//            //    FriendlyWithDogs = false,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 4,
//            //    ShelterId = "a",
//            //    Name = "Aurora",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/aurora-4127-Generic.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Female",
//            //    Characteristics = new string[] { "silly", "2 months" },
//            //    EnergyLevel = "High",
//            //    Age = "Junior",
//            //    Size = "small",
//            //    Type = "Cat",
//            //    Hair = "long",
//            //    Description = "Aurora is a cuddlebug!",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 5,
//            //    ShelterId = "a",
//            //    Name = "Blue",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/blue-2-2610-L.jpg",
//            //    Breed = "Amstaff",
//            //    Gender = "Female",
//            //    Characteristics = new string[] { "shy", "5 years" },
//            //    EnergyLevel = "High",
//            //    Age = "Adult",
//            //    Size = "medium",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = "Blue can be a little shy to start off, but once she warms up she just wants affection.Come down to meet Blue!",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 6,
//            //    ShelterId = "a",
//            //    Name = "Fiona",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/fiona-2-4125-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Female",
//            //    Characteristics = new string[] { "nice", "4 months" },
//            //    EnergyLevel = "High",
//            //    Age = "Junior",
//            //    Size = "medium",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = " I have learned to sit and do my business in the yard and I sleep quietly in my pen all night.  I love my chew toys but I don’t chew on anything else in the house.",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = false,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 7,
//            //    ShelterId = "a",
//            //    Name = "Prince",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/prince-2-4124-L.jpg",
//            //    Breed = "Pitbull",
//            //    Gender = "Male",
//            //    Characteristics = new string[] { "smart", "10 years" },
//            //    EnergyLevel = "Low",
//            //    Age = "Senior",
//            //    Size = "medium",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = "He is dog friendly and seems equally relaxed around cats and kids",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 8,
//            //    ShelterId = "a",
//            //    Name = "Estee",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/estee-2-3945-L.jpg",
//            //    Breed = "Amstaff",
//            //    Gender = "Female",
//            //    Characteristics = new string[] { "lazy", "8 years" },
//            //    EnergyLevel = "Low",
//            //    Age = "Senior",
//            //    Size = "medium",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = "Estee looks like a real bruiser, due to the marks on her face and rough spots where she has recovered from a bad skin infection. But, she really is a super sweet lady.",
//            //    FriendlyWithDogs = false,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 9,
//            //    ShelterId = "a",
//            //    Name = "Adonis",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/adonis-3894-L.jpg",
//            //    Breed = "Pitbull",
//            //    Gender = "Male",
//            //    Characteristics = new string[] { "cozy", "2 years" },
//            //    EnergyLevel = "Low",
//            //    Age = "Adult",
//            //    Size = "medium",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = "He is blind and has a neurological condition, and he used to have a seeing eye dog. He is 2 years old and weighs 40 pounds. He LOVESSSS all people and children, and did super well with a well-mannered dog his size.",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = true
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 10,
//            //    ShelterId = "b",
//            //    Name = "Franji",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/franji-4123-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Female",
//            //    Characteristics = new string[] { "good", "4 months" },
//            //    EnergyLevel = "High",
//            //    Age = "Junior",
//            //    Size = "short",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = "I have such a beautiful glossy black coat, really cute muscular short legs and such adorable ears!!",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 11,
//            //    ShelterId = "b",
//            //    Name = "Bacon",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/bacon-4122-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Female",
//            //    Characteristics = new string[] { "happy", "6 years" },
//            //    EnergyLevel = "High",
//            //    Age = "Adult",
//            //    Size = "small",
//            //    Type = "Cat",
//            //    Hair = "short",
//            //    Description = "Bacon is a gorgeous shy tortie who needs some time and patience at first while she gets to know you. Once she trusts you, she will come out of her shell. She doesn’t much care to be held but she will snuggle up next to you for pets once she feels comfortable. She is fine with a mellow dog, but would be happier as the only cat in the house.",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = false,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 12,
//            //    ShelterId = "b",
//            //    Name = "Shae",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/shae-4121-L.jpg",
//            //    Breed = "Pitbull",
//            //    Gender = "Female",
//            //    Characteristics = new string[] { "playmate", "3 years" },
//            //    EnergyLevel = "High",
//            //    Age = "Adult",
//            //    Size = "medium",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = "Shae is great at sharing and shows no signs of food aggression. She is housebroken and will tell you when she needs to go out. She is also crate trained, knows basic commands and did well when introduced to kids ages 6 & 9.",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 13,
//            //    ShelterId = "b",
//            //    Name = "Brandy",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/brandy-2-3836-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Female",
//            //    Characteristics = new string[] { "sweet", "4 years" },
//            //    EnergyLevel = "High",
//            //    Age = "Adult",
//            //    Size = "small",
//            //    Type = "Cat",
//            //    Hair = "short",
//            //    Description = "Brandy is a shy girl who warms up with treats! She likes to be petted and will pur a lot. She enjoys sleeping in her little hidey hole but will come out and greet you when you enter the room.",
//            //    FriendlyWithDogs = false,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = false,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 14,
//            //    ShelterId = "b",
//            //    Name = "Elena",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/elena-4108-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Female",
//            //    Characteristics = new string[] { "shy", "3 years" },
//            //    EnergyLevel = "Low",
//            //    Age = "Adult",
//            //    Size = "small",
//            //    Type = "Cat",
//            //    Hair = "short",
//            //    Description = "he loves belly rubs and snuggling and just wants to be close to you. She plays with toys and loves her kitty foster sister. She is still unsure of the dogs. She’d make a great addition to any family and would love a kitty sibling!",
//            //    FriendlyWithDogs = false,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 15,
//            //    ShelterId = "b",
//            //    Name = "Nino",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/nino-stt-4109-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Male",
//            //    Characteristics = new string[] { "playful", "3 months" },
//            //    EnergyLevel = "Medium",
//            //    Age = "Junior",
//            //    Size = "medium",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = "He is very playful,  energetic, and great with kids.  He love to chasing tennis balls and play with toys.  Nino plays hard and sleeps well through the night.  He has dark black fur with patches of brown marbling on his legs and chest.  We believe Nino has no sight in one eye, but that doesn't slow him down one bit.  Nino loves to give kisses.",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = true
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 16,
//            //    ShelterId = "b",
//            //    Name = "Sodium",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/sodium-3949-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Male",
//            //    Characteristics = new string[] { "cozy", "2 months" },
//            //    EnergyLevel = "Medium",
//            //    Age = "Junior",
//            //    Size = "small",
//            //    Type = "Cat",
//            //    Hair = "long",
//            //    Description = "My name is Sodium, and I'm a very cute boy who loves to meet new people, play and explore new places.  My favorite toy is any cat toy on a wand that you use to tempt me to chase and hunt.",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 17,
//            //    ShelterId = "c",
//            //    Name = "Samuel",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/samuel-446-L.jpg",
//            //    Breed = "Amstaff",
//            //    Gender = "Male",
//            //    Characteristics = new string[] { "smart", "7 years" },
//            //    EnergyLevel = "Medium",
//            //    Age = "Adult",
//            //    Size = "medium",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = "Samuel can be a bit fearful when meeting new people, and it may take more than one introduction to win his confidence. However once he gets to know you, he shows the super sweet side to his personality. Samuel enjoys his walks and does pretty well on the leash. He doesn’t spend much time playing in the yard; he’d rather sit next to you and have the wrinkles on his neck scratched. Samuel is dog friendly and also very smart.",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = false,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 18,
//            //    ShelterId = "c",
//            //    Name = "Raj",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/raj-stt-4116-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Male",
//            //    Characteristics = new string[] { "cutie pie", "4 months" },
//            //    EnergyLevel = "High",
//            //    Age = "Junior",
//            //    Size = "medium",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = "He is very energetic with a beautiful black brindle coat. He loves getting belly rubs, playing tug of war, and getting tasty treats! He loves his humans and fur friends and will happily spend all day giving you love eyes. He gets along well with his foster sibling and is great with everyone he meets!",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 19,
//            //    ShelterId = "c",
//            //    Name = "George",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/george-mcfly-lincoln-4113-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Male",
//            //    Characteristics = new string[] { "good", "3 years" },
//            //    EnergyLevel = "High",
//            //    Age = "Adult",
//            //    Size = "medium",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = "I am a huge cuddler and when it's play time, I love to play with my human foster parents and canine foster brother. I am already fantastic on the leash and I am working on crate training and basic obedience. I am completely potty trained and I let my foster parents sleep in and get work done. I love other dogs and would enjoy being in a home with another dog. I am sometimes a bit slow to warm up to new people but I promise if you are patient with me, I will be your best friend.",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = false,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 20,
//            //    ShelterId = "c",
//            //    Name = "Witch",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/witch-4102-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Female",
//            //    Characteristics = new string[] { "little", "2 months" },
//            //    EnergyLevel = "High",
//            //    Age = "Junior",
//            //    Size = "medium",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = "Hi everyone! My name is Witch, but my friends call me Little Lady. I can be kind of shy at first, but once you get to know me watch out! I am the only girl but I definitely stand my ground! I am not afraid to stand up to my brothers and play hard all day long. But after a long day, I am always willing to snuggle and give you puppy kisses. I am great with other dogs and love everyone I meet, but I have never met a cat or kids. I am looking for my fur-ever home and I hope it can be with you!",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 21,
//            //    ShelterId = "c",
//            //    Name = "Steven",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/steven-stt-4106-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Male",
//            //    Characteristics = new string[] { "Lazy", "2 years" },
//            //    EnergyLevel = "Low",
//            //    Age = "Adult",
//            //    Size = "small",
//            //    Type = "Cat",
//            //    Hair = "short",
//            //    Description = "He will fall in love with you quickly and become your lifetime partner. He is really affectionate and wants cuddles throughout the whole day. He has some kitten spirit in him where he will love to play with you or with another four-legged friend!",
//            //    FriendlyWithDogs = false,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = false,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 22,
//            //    ShelterId = "d",
//            //    Name = "Warlock",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/warlock-4103-L.jpg",
//            //    Breed = "Amstaff",
//            //    Gender = "Male",
//            //    Characteristics = new string[] { "cuddler", "2 months" },
//            //    EnergyLevel = "Medium",
//            //    Age = "Junior",
//            //    Size = "medium",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = "Hi everyone! My name is Warlock and I am part of the Monster Mash litter. I love to play and snuggle all day! Belly rubs are my favorite activity, besides playing with my siblings, Vampire and Witch. I can sit in your lap and hang out with you all day. I am great with other dogs and people, unknown about cats/children.  I can’t wait to find my fur-ever home and I hope its with you!",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 23,
//            //    ShelterId = "d",
//            //    Name = "Jojo",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/jojo-stt-4104-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Male",
//            //    Characteristics = new string[] { "stinky", "5 months" },
//            //    EnergyLevel = "High",
//            //    Age = "Junior",
//            //    Size = "medium",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = "He’s so affectionate and loyal that he’ll wake up out of a sound sleep to follow and be by his persons side. His curly tail and extremely shiny coat gets him a lot of compliments while we’re out! He is pretty chillin and reminds me of an old soul with his great posture and how he looks at you like a human. ",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 24,
//            //    ShelterId = "d",
//            //    Name = "Stincky",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/sticky-4091-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Male",
//            //    Characteristics = new string[] { "meaw", "5 years" },
//            //    EnergyLevel = "Low",
//            //    Age = "Adult",
//            //    Size = "small",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = "Sticky is 5 years old, and excited to go to his forever home. He is unbelievably friendly and confident in himself, and does very well meeting new people and dealing with loud noises. Sticky loves being in the same room that the action is happening in, even if he is just sleeping.",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = false,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 25,
//            //    ShelterId = "d",
//            //    Name = "Jake",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/jake-st-clair-3573-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Male",
//            //    Characteristics = new string[] { "nice", "11 years" },
//            //    EnergyLevel = "Low",
//            //    Age = "Senior",
//            //    Size = "medium",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = "He loves to play tug of war with you, but also moves on to the next toy just as quickly. He loves going on walks, and is great on the leash. He listens well, can sit and gives paw especially if you have a treat waiting for him. He prefers to not be left in a kennel, but if you leave him out he will not chew anything he should not be chewing. He does not love car rides, but we are working on that.",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 26,
//            //    ShelterId = "e",
//            //    Name = "Party",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/party-animal-4017-L.jpg",
//            //    Breed = "Birmanese",
//            //    Gender = "Male",
//            //    Characteristics = new string[] { "cute", "3 months" },
//            //    EnergyLevel = "High",
//            //    Age = "Junior",
//            //    Size = "small",
//            //    Type = "Cat",
//            //    Hair = "long",
//            //    Description = "My favorite place to be is on your shoulder whenever I possibly can be. This includes when my foster mommy is walking around the apartment, reading, trying to work, etc. I will gladly write an incoherent email for you too when I’m not sleeping on the job in your lap. And did I mention I like to talk? My foster mommy says I sound like a kitty siren sometimes",
//            //    FriendlyWithDogs = false,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 27,
//            //    ShelterId = "e",
//            //    Name = "Brown",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/mr-brown-stt-4060-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Male",
//            //    Characteristics = new string[] { "cozy", "9 years" },
//            //    EnergyLevel = "Low",
//            //    Age = "Senior",
//            //    Size = "medium",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = "Mr.Brown is a very well behaved boy. He can sometimes be a little shy when meeting new people but once he warms up he will give you all the kisses. He loves naps, peanut butter and, lots of pets. He’s house broken and does really well with the commands sit and stay. He also walks great on a leash. Mr.Brown is a big lover and will do about anything for a treat!",
//            //    FriendlyWithDogs = false,
//            //    FriendlyWithCats = false,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 28,
//            //    ShelterId = "e",
//            //    Name = "Cheerios",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/cheerios-4058-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Male",
//            //    Characteristics = new string[] { "nice", "3 months" },
//            //    EnergyLevel = "High",
//            //    Age = "Junior",
//            //    Size = "small",
//            //    Type = "Cat",
//            //    Hair = "short",
//            //    Description = "Cheerios is a cuddly little boy who loves to snuggle.  He is playful and full of wonder.  His little eyes just beg for your attention.  He loves playing with his siblings as well as the resident cat.   This boy will make a wonderful addition to any family!  He is both cat and dog friendly.",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 29,
//            //    ShelterId = "e",
//            //    Name = "Snowy",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/snowy-stt-4031-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Male",
//            //    Characteristics = new string[] { "shy", "2 years" },
//            //    EnergyLevel = "High",
//            //    Age = "Adult",
//            //    Size = "medium",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = "He is crate trained and almost completely potty trained. Loves cuddles, scratches, long walks, hikes, and playing in water. He is so loving! It is clear, he can’t wait to meet his forever family!!",
//            //    FriendlyWithDogs = false,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 30,
//            //    ShelterId = "e",
//            //    Name = "Aubie",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/aubie-3997-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Male",
//            //    Characteristics = new string[] { "meaw", "3 months" },
//            //    EnergyLevel = "High",
//            //    Age = "Junior",
//            //    Size = "small",
//            //    Type = "Cat",
//            //    Hair = "short",
//            //    Description = "He definitely has personality and loves cuddles and scratches. He enjoys playing with his toys and sunbathing in any available window.  He has been a pro with the litter box since he was 4 weeks old!  He will be the perfect addition to any family and can't wait to find his forever home.",
//            //    FriendlyWithDogs = false,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 31,
//            //    ShelterId = "f",
//            //    Name = "Pearl",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/pearl-4025-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Female",
//            //    Characteristics = new string[] { "sleepy", "5 months" },
//            //    EnergyLevel = "Medium",
//            //    Age = "Junior",
//            //    Size = "small",
//            //    Type = "Cat",
//            //    Hair = "short",
//            //    Description = "Pearl is the prettiest little girl. She is a very sweet calico with the most beautiful markings. Pearl can be a shy girl when you first meet her but she loves to play with toys and will be enamored by a rattle or string for hours. Pearl has the cutest little meow when it’s time to eat; it’s really the only time she meows so her little squeaks are extra adorable! ",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 32,
//            //    ShelterId = "f",
//            //    Name = "Rhapsody",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/rhapsody-4126-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Male",
//            //    Characteristics = new string[] { "silly", "3 months" },
//            //    EnergyLevel = "High",
//            //    Age = "Junior",
//            //    Size = "small",
//            //    Type = "Cat",
//            //    Hair = "short",
//            //    Description = "He is very playful and adorable!",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = false,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 33,
//            //    ShelterId = "f",
//            //    Name = "Maple",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/maple-2545-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Female",
//            //    Characteristics = new string[] { "shy", "2 years" },
//            //    EnergyLevel = "Medium",
//            //    Age = "Adult",
//            //    Size = "small",
//            //    Type = "Cat",
//            //    Hair = "short",
//            //    Description = "Little snowy Maple is a perfect pearl of a kitty. She may be slow to come out of her shell, but once you're lucky enough to become her buddy, she's all pouncing and playing and purring. She came in with injuries, but we've played her a lot of Taylor Swift, so she's shakin' it off! This girl just loves having fun. Give her a scratching pole and a catnip toy and she'll show you the time of your life!",
//            //    FriendlyWithDogs = false,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 34,
//            //    ShelterId = "f",
//            //    Name = "Broadway",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/broadway-1828-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Male",
//            //    Characteristics = new string[] { "kind", "8 years" },
//            //    EnergyLevel = "Medium",
//            //    Age = "Senior",
//            //    Size = "medium",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = "",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = false,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 35,
//            //    ShelterId = "f",
//            //    Name = "Cooper",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/mini-cooper-781-L.jpg",
//            //    Breed = "Cane Corso",
//            //    Gender = "Female",
//            //    Characteristics = new string[] { "little", "5 years" },
//            //    EnergyLevel = "High",
//            //    Age = "Adult",
//            //    Size = "big",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = "Mini Cooper is a super sweet mature lady. She is a strong and fairly large dog so pretty perfect to cuddle with. Mini would love a big yard to play in. She is choosy when it comes to liking other dogs, she seems to like smaller boys but would do best living in a home as the only dog. Mini would do best in a home with adult who can put her away or slowly introduce her to new guests. Mini Cooper is a great listener and strong but wonderful on walks. She gets really excited when she sees her friends and WOOFs and then runs in circles. She is easy to meet at the shelter if you have some good treats and a smile. She will never forget a friendly face.",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = false,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//            //animals.Add(new Animal
//            //{
//            //    Id = 36,
//            //    ShelterId = "f",
//            //    Name = "Sugar",
//            //    Image = "https://www.strayrescue.org/media/k2/items/cache/sugar-skull-4118-L.jpg",
//            //    Breed = "Mixed",
//            //    Gender = "Male",
//            //    Characteristics = new string[] { "nice", "3 months" },
//            //    EnergyLevel = "High",
//            //    Age = "Junior",
//            //    Size = "medium",
//            //    Type = "Dog",
//            //    Hair = "short",
//            //    Description = "Sugar Skull is a male 10 week old whose Mom is a Catahoula Leopard Dog. He is one of 7 in his litter. He is curious but cautious. He loves playing with his sibling but is cautious around large dogs. He is being crate trained. He is a snuggler.",
//            //    FriendlyWithDogs = true,
//            //    FriendlyWithCats = true,
//            //    FriendlyWithKids = true,
//            //    SpecialNeeds = false
//            //});
//        }


//        // GET: api/<AnimalsController>
//        [Route("/animals")]
//        [HttpGet]
//        public ActionResult<List<Animal>> Get()
//        {
//            return animals;
//        }

//        // GET api/<AnimalsController>/5
//        [Route("/animals/{id}")]
//        [HttpGet("{id}")]
//        public ActionResult<Animal> Get(int id)
//        {
//            return animals.Where(x => x.Id == id).First();
//        }

//        [Route("/animals/shelter/{shelter_id}")] //shelters/shelter_id/animals
//        [HttpGet("{shelter_id}")]
//        public ActionResult<List<Animal>> Get(string shelter_id)
//        {
//            return animals.Where(x => x.ShelterId == shelter_id).ToList();
//        }







//        //// POST api/<AnimalsController>
//        //[HttpPost]
//        //public void Post([FromBody] string value)
//        //{
//        //}

//        //// PUT api/<AnimalsController>/5
//        //[HttpPut("{id}")]
//        //public void Put(int id, [FromBody] string value)
//        //{
//        //}

//        //// DELETE api/<AnimalsController>/5
//        //[HttpDelete("{id}")]
//        //public void Delete(int id)
//        //{
//        //}
//    }
//}
