<template>
  <div class="details-wrapper">
      <!-- <div class="loading" v-if="loadingContent">

        </div>-->

       <Loading/>

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
          </ul>
        </div>

        <div class="event-desc">
          <div class="description">
            <p>Description</p>
          </div>

          <p>{{ currEvent.description }}</p>
        </div>
      </div>
      <div class="btn-join" >
        <v-btn elevation="11" x-large v-if="!ifHost && !getJoined">Join</v-btn>
   <v-btn elevation="11" x-large disabled v-if="getJoined">Joined</v-btn>
      </div>
    </v-card>
  </div>
</template>

<script>
import Loading from '../components/Loading.vue'
export default {
  components:{
Loading
  },
  data() {
    return {
      dialog: false,
      deletePopup: false,
      afterDelete: false,
     // joined:false
     
    };
  },

  watch: {
    dialog(val) {
      if (!val) return;

      setTimeout(() => this.redirect(), 3000);
    },
  },

  methods: {
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

    async deleteEvent() {
      this.dialog = false;
      await this.$store.dispatch("deleteEvent", this.currEvent.id);
      if (this.$store.state.deleteSuccess) {
        this.afterDelete = true;
      }
    },

    editEvent() {
      this.$router.push("/update-event/" + this.currEvent.id);
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

li > p {
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

 li > p, .event-desc>p{
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

  
 li > p, .event-desc>p{
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

 li > p, .event-desc>p{
   font-size:1.4vh;
 }
}
@media only screen and (max-width: 360px){
 li > p, .event-desc>p{
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
</style>
