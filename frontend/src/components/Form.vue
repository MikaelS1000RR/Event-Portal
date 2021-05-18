<template>
  <div class="wrapper">
    <h3>Create new event</h3>
    <form @submit.prevent="onCreateEvent">
      <p>
        <label id="eventName" for="">Event name</label>
        <input type="text" v-model="eventName" />
      </p>
      <p>
        <label id="location" for="">Location</label>
        <input type="text" v-model="location" />
      </p>

      <p>
        <label id="time1" for="">Start Time</label>
        <input type="datetime-local" id="time" v-model="startTimeAndDate" />
      </p>

      <p>
        <label id="time2" for="">End Time</label>
        <input type="datetime-local" id="time" v-model="endTimeAndDate" />
      </p>

      <p>
        <label id="description" for="">Description</label>
        <textarea v-model="description" name="" id="" cols="30" rows="7">
        </textarea>
      </p>
      <div class="accessibility">
        <div class="access-label">
          <p>Choose accessibility:</p>
          <HelpCircle />
        </div>

        <v-dialog v-model="dialog" hide-overlay persistent width="300">
          <v-card color="primary" dark>
            <v-card-text v-if="$store.state.success">
              Event has been created
            </v-card-text>
            <v-card-text v-else>
              Something went wrong
            </v-card-text>
          </v-card>
        </v-dialog>



        <v-dialog v-model="notAllInputsFilled" hide-overlay persistent width="300">
          <v-card color="primary" dark>
            <v-card-text>
              Please fill in all the fields
            </v-card-text>
           
          </v-card>
        </v-dialog>

        <p class="checkbox">
          <img class="door" src="../assets/CreateEventImg/door.png" />
          <label for="public">Public</label>

          <input
            id="public"
            value="Public"
            type="checkbox"
            v-model="publicAccess"
            @change="disablePrivateAndInternal"
          />

          <img class="lock" src="../assets/CreateEventImg/padlock.png" />
          <label for="private">Private</label>

          <input
            id="private"
            value="Private"
            type="checkbox"
            v-model="privateAccess"
            @change="disablePublicAndInternal"
          />

          <img class="key" src="../assets/CreateEventImg/key (1).png" />
          <label for="internal">Internal</label>

          <input
            id="internal"
            value="Internal"
            type="checkbox"
            v-model="internalAccess"
            @change="disablePublicAndPrivate"
          />
        </p>
      </div>

      <p>
        <button type="submit" class="btn btn-primary">Create</button>
      </p>
    </form>
  </div>
</template>

<script>

import HelpCircle from "../components/HelpCircle.vue";
export default {
  components: {
    HelpCircle,
  },
  data() {
    return {
      eventName: "",
      location: "",
      startTimeAndDate: "",
      endTimeAndDate: "",

      description: "",
      publicAccess: true,
      privateAccess: false,
      internalAccess: false,
      access: "public",
      hostId: this.$store.state.account.homeAccountIdentifier,
      hostName: this.$store.state.account.name,
      dialog: false,
      notAllInputsFilled:false
    };
  },
  watch: {
    dialog(val) {
      if (!val) return;

      setTimeout(() => this.redirect(), 1500);
    },
    notAllInputsFilled(val) {
      if (!val) return;

      setTimeout(() => this.notAllInputsFilled=false, 1500);
    },


  },


  methods: {
    async onCreateEvent() {
      if(this.eventName==="" || this.location==="" || this.startTimeAndDate===""|| this.endTimeAndDate==="" || this.description===""){
         this.notAllInputsFilled=true;
       
         
      }
      else{
        const startDateTime = `${this.startTimeAndDate}:59.3528866+02:00`;
      const endDateTime = `${this.endTimeAndDate}:59.3528866+02:00`;

      const createdEvent = {
        name: this.eventName,
        location: this.location,
        startDateTime: startDateTime,
        endDateTime: endDateTime,
        description: this.description,
        access: this.access,
        hostId: this.hostId,
        hostName: this.hostName,
      };

      console.log("event is form is", createdEvent);

      this.$store.commit("setCreatedEvent", createdEvent);
      await this.$store.dispatch("createNewEvent");
      this.dialog = true;
      }
     
      
    },

    redirect() {
      this.afterCreate = false;
      this.$store.commit("setSuccess", false);
      this.$router.push("/");
    },
    disablePublicAndInternal() {
      this.access = "private";
      this.publicAccess = false;
      this.internalAccess = false;
    },
    disablePrivateAndInternal() {
      this.access = "public";
      this.privateAccess = false;
      this.internalAccess = false;
    },

    disablePublicAndPrivate() {
      this.access = "internal";
      this.privateAccess = false;
      this.publicAccess = false;
    },
  },
};
</script>

<style scoped>
* {
  box-sizing: border-box;
  font-family: "Montserrat", sans-serif;
}

body {
  padding-top: 1rem;
}

.v-dialog > .v-card > .v-card__text {
  padding: 2vh 3vw 2vh 3vw;
  display: flex;

  justify-content: center;
}

.v-dialog > .v-card > .v-card__title {
  font-size: 1.1em !important;
  font-family: "Montserrat", sans-serif !important;
}
.v-application .primary {
  background-color: var(--buttonPurpleSecondary) !important;
}

.wrapper {
  max-width: 700px;
  margin: 0 auto;
  padding: 1em;
  background: #f9f9f9;
  border: 1px solid #c1c1c1;
}

h3 {
  margin: 0;
}

input:focus,
textarea:focus {
  outline: 3px solid rgba(107, 21, 206, 0.233);
}

input,
textarea,
button {
  width: 100%;
  border: 1px solid #000;
}

.wrapper > * {
  padding: 1em;
}

form label {
  display: block;
}

form p {
  margin: 0;
}

button,
input,
textarea {
  padding: 1em;
}

button {
  background: lightgrey;
  width: 100%;
  border: 0;
}
button:hover,
button:focus {
  background: rgba(107, 21, 206, 0.548);
  outline: 0;
}

form {
  display: grid;
  grid-gap: 20px;
}
form p {
  grid-column: 1 / 2;
}

.input-file-wrapper {
  grid-column: 2 / 3;
  grid-row: 1 / 2;
}

.accessibility {
  grid-column: 1/2;
  margin-top: 2vh;
}

.access-label {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}

.checkbox {
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  padding-top: 2vh;
}

#public,
#private,
#internal {
  cursor: pointer;
  outline: none;
  margin-right: 1vw;
}

.door {
  width: 9%;
}

.lock,
.key {
  width: 8%;
  padding-bottom: 0.5%;
}
</style>
