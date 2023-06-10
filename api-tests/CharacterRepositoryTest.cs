using DnDAPI.Contracts;
using DnDAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace api_tests
{
    internal class CharacterRepositoryTest : ICharacterRepository
    {
        private readonly List<Character> _characterList;

        public CharacterRepositoryTest()
        {
            _characterList = new List<Character>()
            {
                new Character() { 
                    CharacterId = 1,
                    Name = "Lord Foo",
                    Level = 20,
                    Class = "Wizard",
                    Archetype = "Shadow Wizard",
                    Background = "Noble",
                    Alignment = "TN",
                    STR = 5,
                    DEX = 10,
                    CON = 15,
                    INT = 20,
                    WIS = 25,
                    CHA = 30
                }
            };
        }

        public Task Create(Character entity)
        {
            throw new NotImplementedException();
        }

        public Task<Character> Get(Expression<Func<Character, bool>> filter = null, bool tracked = true)
        {
            throw new NotImplementedException();
        }

        public Task<List<Character>> GetAll(Expression<Func<Character, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Character entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Character> Update(Character entity)
        {
            throw new NotImplementedException();
        }
    }
}
