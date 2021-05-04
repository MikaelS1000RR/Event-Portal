<template>
  <div class="details-wrapper">
      
       <Loading/>
          <v-dialog
    v-model="guestLoginPopup"
      max-width="500px"
      class="guest-dialog"
    >
           <v-card width="500px" class="mt-5 mx-a">
          <v-card-title class="pb-0">
            <h2 class="join-as-guest">Join as Guest</h2>
             </v-card-title>
            <v-card-text>
              <v-form @submit.prevent="joinEventAsGuest">
                <v-text-field
                  id="userName"
                  v-model="name"
                  label="Username"
                  prepend-icon="mdi-account-circle"
                />
              
            
             <v-card-actions class="guest-actions">
                  <v-btn @click="joinedSuccess"  class="join-btn guest-btn" type="submit">JOIN</v-btn >

                </v-card-actions>
                  <transition name="fade" mode="out-in">
                   <div v-if="isJoined" class="alert" role="alert">
      <v-card
        color="primary"
        dark
      >
       <v-card-text class="successfull-join">
          Joined successfully!
        </v-card-text>
         </v-card>
    </div>
     </transition>
            <v-divider></v-divider>
         

          <v-card-title class="pb-0">
            <h2 class="join-as-guest">OR</h2>
            </v-card-title>
            
          

          <v-card-actions class="guest-actions">
            <v-btn
              class="login guest-btn"
              type="submit"
              :color="type === 'guest' ? 'secondary' : '#9933FF'"
              >Login</v-btn
            >
            
           
          </v-card-actions>
              </v-form>
          </v-card-text>
        </v-card>
    </v-dialog>
       
 
    <vue-fontawesome icon="file" size="2" color="lightgray"></vue-fontawesome>
    <v-card :loading="loading" class="mx-auto my-12" outlined shaped tile>
      <div class="event-name">
       
        <p>{{ currEvent.name }}</p>
       
        <v-menu offset-y transition="slide-y-transition" bottom>
          <template v-slot:activator="{ on, attrs }">
            <img
              class="detailedImg settings"
              v-bind="attrs"
              v-on="on"
              src="../assets/DetailedImg/setting.png"
              alt=""
            />
          </template>
          <v-list>
            <v-list-item-title class="dropdown-item" @click="editEvent"
              >Edit
            </v-list-item-title>

            <v-dialog v-model="dialog" width="500">
              <template v-slot:activator="{ on, attrs }">
                <v-list-item-title
                  v-bind="attrs"
                  v-on="on"
                  class="dropdown-item"
                  >Delete</v-list-item-title
                >
              </template>

              <v-card>
                <v-card-title class="headline grey lighten-2">
                  Are you sure that you want to delete this event?
                </v-card-title>

                <v-divider></v-divider>

                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn color="primary" text @click="deleteEvent">
                    Yes
                  </v-btn>
                  <v-btn color="primary" text @click="dialog = false">
                    Cancel
                  </v-btn>
                </v-card-actions>
              </v-card>
            </v-dialog>
          </v-list>
        </v-menu>

        <v-dialog v-model="afterDelete" hide-overlay persistent width="300">
          <v-card color="primary" dark>
            <v-card-text v-if="$store.state.deleteSuccess">
              Event has been deleted
            </v-card-text>
            <v-card-text v-else>
              Something went wrong
            </v-card-text>
          </v-card>
        </v-dialog>
      </div>

      <div class="event-details">
        <div class="event-info">
          <ul>
            <li>
              <img
                class="detailedImg"
                src="../assets/DetailedImg/place.png"
                alt=""
                srcset=""
              />
              <p>{{ currEvent.location }}</p>
            </li>

            <li>
              <img
                class="detailedImg"
                src="../assets/DetailedImg/clock.png"
                alt=""
                srcset=""
              />

              <p>{{ time }}</p>
            </li>

            <li>
              <img
                class="detailedImg"
                src="../assets/DetailedImg/calendar.png"
                alt=""
                srcset=""
              />

              <p class="dates">{{ dates }}</p>
            </li>

            <li>
              <img
                class="detailedImg"
                src="../assets/DetailedImg/user.png"
                alt=""
              />
              <p>{{ hostUser.firstName }} {{ hostUser.lastName }}</p>
            </li>

            <li>
              <img
                class="detailedImg"
                v-if="currEvent.access === 'private'"
                src="../assets/CreateEventImg/lock.png"
                alt=""
              />

              <img
                class="detailedImg"
                v-if="currEvent.access === 'public'"
                src="../assets/DetailedImg/open-lock.png"
                alt=""
                srcset=""
              />
              <img
                class="detailedImg"
                v-if="currEvent.access === 'internal'"
                src="../assets/DetailedImg/key.png"
                alt=""
                srcset=""
              />

              <p>{{ currEvent.access }}</p>
            </li>
            <li>
              <div class="people-count">
                <p>People going:</p>
                <p>{{$store.state.specEvent.joinedUsers.length}}</p>
              </div>
            </li>
          </ul>
        </div>

        <div class="event-desc">
          <div class="description">
            <p>Description</p>
          </div>

          <p>{{ currEvent.description }}</p>
        </div>
      </div>
      <div class="btnJoin" >
        
       
         <v-btn class="joinBut" elevation="11" x-large @click="joinEvent"> Join 
         </v-btn>

   
      </div>


      
      
    </v-card>
    
  </div>
</template>

<script>
import Loading from '../components/Loading.vue'

export default {
  components:{

Loading,


  },
  data() {
    return {
      dialog: false,
      deletePopup: false,
      afterDelete: false,
      guestLoginPopup:false,
      isJoined: false,
      afterJoin: false,
      name: ''
         
    };
  },

  watch: {
    dialog(val) {
      if (!val) return;

      setTimeout(() => this.redirect(), 3000);
    },

    isJoined(val) {
      if(!val) return; 
        setTimeout(() => this.afterJoinRedirect(), 2000)
      
       

    }

  },

  methods: {
    joinedSuccess() {
      this.isJoined = true;
    },
    
    getDate(eventDate) {
      const monthNames = ["january", "february", "march", "april", "may", "june",
  "july", "august", "september", "cotober", "november", "december"
];

var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];

      var startDt = new Date(eventDate);
      const startDay = startDt.getDate(),
        startMonth = monthNames[startDt.getMonth()],
        day=days[startDt.getDay()],
        date = day+" "+startDay + " " + (startMonth);
      return date;
    },

    redirect() {
      this.afterDelete = false;
      this.$router.push("/");
    },

    afterJoinRedirect() {
      
      this.$router.push("/");
    },

    async deleteEvent() {
      this.dialog = false;
      await this.$store.dispatch("deleteEvent", this.currEvent.id);
      if (this.$store.state.deleteSuccess) {
        this.afterDelete = true;
      }
    },

    async joinEventAsGuest(){
     await this.$store.dispatch("guestJoinEvent", this.name)
    },

    editEvent() {
      this.$router.push("/update-event/" + this.currEvent.id);
    },

    joinEvent(){
      console.log(this.$store.state.currLoggedInUser.id);
       if(this.$store.state.currLoggedInUser.id===undefined){
              this.guestLoginPopup=true
       }
    },

    getTime(eventDate) {
      var dt = new Date(eventDate);

      const hours = dt.getHours();
      const minutes = dt.getMinutes();
      if (minutes === 0) {
        let time = hours + " : 00";
        return time;
      } else if (hours === 0) {
        let time = "00 : " + minutes;
        return time;
      } else if (hours === 0 && minutes === 0) {
        let time = "00 : 00";
        return time;
      } else {
        let minsLength=minutes+""
        if(minsLength.length===1){
           let time = hours + " : 0" + minutes;
        return time;
        }
        let time = hours + " : " + minutes;
        return time;
      }
    },
  },

  computed: {

    
    currEvent() {
      return this.$store.state.specEvent;
    },
    hostUser() {
      return this.$store.state.specUser;
    },
    id() {
      return this.$route.params.id;
    },


    ifHost() {
      let userIsHost =
       this.hostUser.id === this.$store.state.currLoggedInUser.id
          ? true
          : false
      return userIsHost;
    },

   getJoined(){
    let joined=this.$store.state.specEvent.joinedUsers.includes(this.$store.state.currLoggedInUser)? true:false
       return joined
    },

    dates() {
      const startDate = this.getDate(this.currEvent.startDateTime);
      const endDate = this.getDate(this.currEvent.endDateTime);

      if (startDate === endDate) {
        return startDate;
      }
      if (startDate !== endDate) {
        const generalDate = `${startDate}  -  ${endDate}`;
        return generalDate;
      }

      return this.getDate(this.currEvent.startDateTime);
    },

    time() {
      const startTime = this.getTime(this.currEvent.startDateTime);
      const endTime = this.getTime(this.currEvent.endDateTime);
      const times = `${startTime} - ${endTime}`;
      return times;
    },
  },
  async created() {
    console.log('before fech', this.$store.state.loading);
    await this.$store.dispatch("fetchSpecEvent", this.id);
    
  },
};
</script>

<style scoped>
.details-wrapper {
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
}

.v-dialog > .v-card > .v-card__text {
  padding: 2vh 3vw 2vh 3vw;
  display: flex;

  justify-content: center;
}



.guest-actions{
  justify-content: center !important;
}


.v-application .primary {
  background-color: var(--buttonPurpleSecondary) !important;
}
.dropdown-item {
  cursor: pointer;
}
.v-dialog > .v-card > .v-card__title {
  font-size: 1.1em !important;
  font-family: "Montserrat", sans-serif !important;
}

.v-application .grey.lighten-2 {
  background-color: var(--buttonPurpleSecondary) !important;
}

.my-12 {
  width: 90vw;

  background-color: white;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: flex-end;
  padding-right: 2vw;
}

.v-sheet.v-list {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

.theme--light.v-list {
  background-color: rgba(0, 0, 0, 0.5) !important;
  color: white;
}

.v-list-item__title {
  padding: 0 1.5vw 1vh 1.5vw;
}

.event-name {
  width: 100%;
  height: 20%;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-between;

  font-weight: bold;
  font-size: 1.5vw;
  padding-left: 2vw;
  padding-top: 1vw;
}

.pb-0{
  display: flex;
  align-items: center;
  justify-content: center;
}

.v-menu__content {
  margin-left: -2.5vw;
}
.event-details {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  justify-content: center;
  align-items: center;
  width: 100%;
}

.guest-btn{
  width:300px  !important;
}

.detailedImg {
  width: 8%;
}

ul {
  list-style-type: none;
}

ul > li {
  display: flex;
  flex-direction: row;
  padding: 1.5vw;
  align-items: center;
  text-align: center;
}

li > p, .people-count {
  margin-top: 1.2vw;
  padding-left: 1vw;
  font-size: 1.2vw;
}

.event-desc {
  display: grid;
  grid-auto-rows: 15% 85%;
  height: 100%;
  padding-top: 2.6vw;
}

.description {
  font-weight: 500;
}

.joinBut {

 margin-bottom: 2vw;
  margin-right: 5vw;
}
.btn-join {
  margin-top: -3vw;
  padding-bottom: 1vw;
  margin-right: 8vw;
  min-height:50px;
}
.theme--light.v-btn.v-btn--has-bg {
  background-color: var(--buttonPurple);
}
.v-btn:not(.v-btn--round).v-size--x-large {
  width: 10vw;
  height: 5vh;
}

.settings {
  width: 3%;
  cursor: pointer;
  transition: transform 0.2s;
}

.settings:hover {
  transform: scale(1.1);
}

@media only screen and (max-width: 930px) {
 .v-btn:not(.v-btn--round).v-size--x-large[data-v-14d957f8]{
   font-size:1.5vw;
 }

 .v-btn:not(.v-btn--round).v-size--x-large[data-v-14d957f8]{
   width:12vw;
   height:4vw;
 }

 .event-desc, .event-info{
   height:70vh;
 }

 li > p, .event-desc>p, .people-count{
   font-size:1.5vw;
 }


}

@media only screen and (max-width: 790px) {
  
.detailedImg {
  width: 12%;
}

.settings{
  width:5%;
}

ul>li{
  margin-top:4vw;
}
}

@media only screen and (max-width: 610px) {

  
 li > p, .event-desc>p, .people-count{
   font-size:2vh;
 }


.event-details{
  grid-template-rows: repeat(2, 1fr);
  grid-template-columns: 1fr;
}

.event-info{
  display: flex;
  flex-direction: column;
}
 .detailedImg {
  width: 40px;
}

.event-desc{
 
  margin-left:2vw;
}
.settings{
  width:5%;
}

ul>li{
  margin-top:5vw;
}

.event-name>p{
  font-weight: 500;
  font-size:1.8em;
}

}

@media only screen and (max-width: 510px) {

.event-desc{
 
  margin-top:-2vw;
}

.v-btn:not(.v-btn--round).v-size--x-large[data-v-14d957f8]{
   font-size:2vw;
 }

 .v-btn:not(.v-btn--round).v-size--x-large[data-v-14d957f8]{
   width:20vw;
   height:5vw;
 }

 .event-info{
  height:auto;
  margin-bottom:5vh;
 }

}

@media only screen and (max-width: 510px) {
  .detailedImg {
  width: 30px;
}
.settings{
  width:5%;
}

 li > p, .event-desc>p, .people-count{
   font-size:1.4vh;
 }
}
@media only screen and (max-width: 360px){
 li > p, .event-desc>p, .people-count{
   font-size:1.2vh;
 }

   .detailedImg {
  width: 20px;
}
.settings{
  width:5%;
}



 .event-info{

  margin-top:-15vh;
 }


.event-desc{
  margin-top:-10vh;
}
.event-name{
  font-size:2.5vw;
}
}
@media only screen and (min-width: 340px){
 
}

 .close-container {
position: absolute;
	 margin: auto;
	 width: 50px;
	 height: 50px;
	
	 cursor: pointer;
    top: 1%;
    right: 1%;
}



 .leftright {
	 height: 4px;
	 width: 40px;
	 position: absolute;
	 margin-top: 24px;
	 background-color: #0008fffe;
	 border-radius: 2px;
	 transform: rotate(45deg);
	 transition: all 0.3s ease-in;
}
 .rightleft {
	 height: 4px;
	 width: 40px;
	 position: absolute;
	 margin-top: 24px;
	 background-color: #0108d0fe;
	 border-radius: 2px;
	 transform: rotate(-45deg);
	 transition: all 0.3s ease-in;
}
 label {
	 color: white;
	 font-family: Helvetica, Arial, sans-serif;
	 font-size: 0.4em;
	 text-transform: uppercase;
	 letter-spacing: 2px;
	 transition: all 0.3s ease-in;
	 opacity: 0;
}
 .close {
	 margin: 50px 0 0 5px;
	 position: absolute;
}
 .close-container:hover .leftright {
	 transform: rotate(-45deg);
	 background-color: #f25c66;
}
 .close-container:hover .rightleft {
	 transform: rotate(45deg);
	 background-color: #f25c66;
}
 .close-container:hover label {
	 opacity: 1;
}
 
.alert {
  background-color: rgba(231, 223, 240, 0.797);
  padding: 3px;
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 1.3s ease;
}

.fade-enter,
.fade-leave-to {
  opacity: 0;
}

</style>
