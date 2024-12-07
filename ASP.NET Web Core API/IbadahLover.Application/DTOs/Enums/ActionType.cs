using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.Enums
{
    public enum ActionType //For when logging to azure blob storage in json format
    {
        Create, //record was created
        Read, //record was read
        Update, //record was updated
        Delete, //a record was deleted
        perform, //user performed dhikr
        track, //user tracked salah
        confirm, //confirm a user email or profile picture type or anything else needing comfirmation
        reject, //reject demand or request of a user to change profile picture type if non-compliance with terms and conditions (advanced feature idea for future maybe insha allah)
        ban, //ban a user
        unban, //unban a user if falsly banned (like user contact support and justify so support unban the user)
        warn, //give a user a warning with warning type details
        unwarn, //remove a warning from a user if falsly warned (like user contact support and justify so support remove the warning)
        //Approve,
        //Reject,
        //Cancel,
        //Confirm,
        //Send,
        //Receive,
        //Finish,
        //Start,
        //Stop,
        //Pause,
        //Resume,
        //Add,
        //Remove,
        //Assign,
        //Unassign,
        //Register,
        //Unregister,
        //Subscribe,
        //Unsubscribe,
        //Follow,
        //Unfollow,
        //Like,
        //Unlike,
        //Share,
        //Report,
        //Block,
        //Unblock,
        //Mute,
        //Unmute,
        //Search,
        //Filter,
        //Sort
    }
}
