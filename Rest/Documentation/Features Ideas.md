go from DhikrCount to AfterSalah! to IbadahTracker! to IbadahLover???

### Analytics

user activity gelinkt met nieuw tabbel Session
met session duration, aantal session. session datum

### Customization:

**Profile**:

Custom Profile picture : hardcoded set of different images to choose from, NOT ALLOWING USER TO UPLOAD OWN Profile Picture Because of lack of censoring for project!
EXCEPT for users with permission to modify profile picture (user role permissions handling)

Other app background color

### Functionality

speach recognizion to don't click any button for dhikr incrementation but only listen to audio and increment while doing dhikr out loud (gladia free tier api)

adding to speach recognition, to combine multiple dhikrs types by letting ai transcribe and increment in appropriate dhikr type count!

#### alternative to AI speach recognition (for dhikr incrementing)
**Alternative 1:**
AutoIncrement minimum after 2 Seconds (user configuration can put more) for Allahu Akbar Mode (limited to 10 increments then user input necessary)
AutoIncrement minimum after 3 Seconds (user configuration can put more) for Soubhanallahi wa bihamdih Mode (limited to 10 increments then user input necessary)
pros: free, easy to implement, customizable, it lets you do dhikr without needing to click on increment button, you do dhikr at ease
cons: you need to do dhikr in same rithme, if you loose rithme you are unsynched with auto increment and it is frustrating. will let you speed up dhikr to be on pair synced with auto increment so dhikr quality and ibadah quality badder. (Can be solved trhough user configuration because it is client side only implementation by increasing time intervalle but will surely be a step more most won't do so speed up) 

Alternative 2:
capture audio, look at peak of volumue to determine when user finished dhikr and then increment (intervalle of increment permission)
pros: free, cheat prevention (user needs to do it outloud), force user to put intervalle between dhikr so it can detect finished and increment so improve dhikr activity and ibadah quality
cons: there need to be no background sound so silent envirement. Doesn't interpret sound so it can be anything else than dhikr. putting time restriction is more difficult because more user disconfort to click again on button record audio (user may not notice it stopped recording audio and incrementing therefore dhikr activity not tracked, very frustrating for user))


Button next to increment button for playing in loop a recitor doing dhikr to do dhikr with same ritme:
exemple: Subhanallahi Wa Bihamdih (Gloire et Louange à Allah) 100x https://youtu.be/4ISbG34WHeY?si=b4rK17zbeNB62G3p

Add button loop own dhikr, so you click on record, say the dhikr, then stop the recording and it will loop your own dhikr, you click on the icon and it will stop.

Islamic Finder free api to know prayer times to send notification when prayer time comes. (for future salah tracker implementation)

Daily/Montly Goals! 100 or 33 times dhikr per day objective!

Heatmap of Activity (color to show goals completion per day) :
![image](https://github.com/user-attachments/assets/a4bde5aa-4b70-49d3-a707-6ecc31f721e4)

USING Chart.js library for it!!!

# Out of Scope
// implement Dua tracking
// Implement Quran Tracking
// Implement Mosque Tracking (trhough location detection, when in a mosque for a period of time adds to list of visited mosque)
// deskband app for tracker (wpf)
// Rainmeter skin for windows widget
// Public API to let advanced users and developers communicate with my database for their own extensions, export users data to another tracking service and so on...
// Implement importing tracked data from other reliable sources Only  (limited scope to trustworthy dhikr counitng apps for authenticity of leaderboard like Zikr App for exemple... problem, i don't think they have api for that)
