using System;

namespace advanced_oop_demo
{
    interface ICastMagic
    {
        int mana{get;set;} //{get;set;} is the way of saying "hey, you have the ability to read and write this mana attribute" to whatever class is using this interface. it is an auto-implemented property.

        void castSpell();
    }
}