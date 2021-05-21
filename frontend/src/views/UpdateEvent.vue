<template>
  <div class="update-wrapper">
    <form @submit.prevent="saveChanges">
      <v-card :loading="loading" class="mx-auto my-12" outlined shaped tile>
        <div class="event-details">
          <div class="event-info">
            <ul>
              <li>
                <img
                  class="detailedImg"
                  src="../assets/DetailedImg/event-name.png"
                  alt=""
                />
                <input type="text" v-model="eventName" placeholder="" />
              </li>
              <li>
                <img
                  class="detailedImg"
                  src="../assets/DetailedImg/place.png"
                  alt=""
                  srcset=""
                />
                <input type="text" placeholder="" v-model="location" />
              </li>

              <li>
                <img
                  class="detailedImg"
                  src="../assets/DetailedImg/calendar.png"
                  alt=""
                  srcset=""
                />

                <input
                  type="datetime-local"
                  placeholder=""
                  v-model="startTimeAndDate"
                />
                <span>to</span>
                <input
                  type="datetime-local"
                  placeholder=""
                  v-model="endTimeAndDate"
                />
              </li>

              <li>
               <HelpCircle/>

                <label for="public">Public</label>

                <input
                  id="public"
                  value="Public"
                  type="checkbox"
                  v-model="publicAccess"
                  @change="disablePrivateAndInternal"
                />

                <label for="private" class="lock-label">Private</label>

                <input
                  id="private"
                  value="Private"
                  type="checkbox"
                  v-model="privateAccess"
                  @change="disablePublicAndInternal"
                />
                <label for="internal" class="lock-label">Internal</label>

                <input
                  id="private"
                  value="Private"
                  type="checkbox"
                  v-model="internalAccess"
                  @change="disablePublicAndPrivate"
                />
              </li>

              <li>
                <div class="save-btn hide-on-small">
                  <v-btn
                    class="ma-2"
                    :loading="loading"
                    :disabled="loading"
                    color="success"
                    @click="loader = 'loading'"
                    type="submit"
                  >
                    Save changes
                    <template v-slot:loader>
                      <span>Saving...</span>
                    </template>
                  </v-btn>
                  <v-btn @click="cancel">
                    Cancel
                  </v-btn>
                </div>
              </li>
            </ul>
          </div>
        </div>

            <v-dialog v-model="badRequest" width="500">
              

              <v-card>
                <v-card-title class="headline grey lighten-2">
                  Please fill in the dates
                </v-card-title>
                

                <v-divider></v-divider>

                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn color="primary" text @click="badRequest=false">
                   Ok
                  </v-btn>
                 
                </v-card-actions>
              </v-card>
            </v-dialog>

        <div class="event-desc">
          <div class="description">
            <p>Description</p>
          </div>

          <textarea v-model="description" name="" id="" cols="30" rows="7">
          </textarea>
            <div class="save-btn hide">
                  <v-btn
                    class="ma-2 save-btn"
                    :loading="loading"
                    :disabled="loading"
                    color="success"
                    @click="loader = 'loading'"
                    type="submit"
                  >
                    Save changes
                    <template v-slot:loader>
                      <span>Saving...</span>
                    </template>
                  </v-btn>
                  <v-btn @click="cancel">
                    Cancel
                  </v-btn>
                </div>
        </div>
      </v-card>
    </form>
  </div>
</template>

<script>
import HelpCircle from '../components/HelpCircle.vue'
export default {
  components:{
  HelpCircle
  },
  data() {
    return {
      eventName: this.$store.state.specEvent.name,
      location: this.$store.state.specEvent.location,
      startTimeAndDate: "",
      endTimeAndDate: "",
      description: this.$store.state.specEvent.description,
      publicAccess: this.$store.state.publicAccess,
      privateAccess: this.$store.state.privateAccess,
      internalAccess: this.$store.state.internalAccess,
      access: "public",
      loader: null,
      loading: false,
      badRequest:false
    };
  },
  methods: {
    async saveChanges() {
      const l = this.loader;
      this[l] = !this[l];

      await new Promise((res) => setTimeout(res, 3000));

      this[l] = false;
      this.loader = null;
      if(this.startTimeAndDate !== "" && this.endTimeAndDate !== "")
      {
      const startDateTime = `${this.startTimeAndDate}:59.3528866+02:00`;
      const endDateTime = `${this.endTimeAndDate}:59.3528866+02:00`;
      const updatedEvent = {
        name: this.eventName,
        location: this.location,
        startDateTime: startDateTime,
        endDateTime: endDateTime,
        description: this.description,
        access: this.access,
      };

      await this.$store.commit("setUpdatedEvent", updatedEvent);
      await this.$store.dispatch("updateEvent");

      this.$router.push("/details/" + this.$store.state.specEvent.id);
      }
      else{
         this.badRequest=true;
      }
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

    cancel() {
      this.$router.push("/details/" + this.$store.state.specEvent.id);
    },
  },
  computed: {},

  async created() {},
};
</script>

<style scoped>
.update-wrapper {
  width: 100%;
  height: 100vh;
  color: white;
}



.detailedImg {
  width: 8%;
  padding-right: 1vh;
}

.event-desc {
  display: grid;
  width: 50%;
  height:100%;
  grid-auto-rows: 15% 85%;

  padding-top: 2.6vw;
  padding-bottom: 10vh;
}
.v-application .grey.lighten-2 {
  background-color: var(--buttonPurpleSecondary) !important;
}

.v-dialog > .v-card > .v-card__title {
  font-size: 1.1em !important;
  font-family: "Montserrat", sans-serif !important;
}

.v-application .success {
  background-color: var(--buttonPurple) !important;
}

li > span {
  padding: 0 1vw 0 1vw;
}

input,
textarea {
  border: 1px solid #000 !important;
  padding: 0.5vw 1vw 0.5vw 1vw;
}


input:focus,
textarea:focus {
  outline: 3px solid rgba(107, 21, 206, 0.233);
}

.description {
  font-weight: 500;
}
.my-12 {
  width: 90vw;
  

  background-color: white;
  display: flex;
  flex-direction: row;
  padding-right: 2vw;
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

li > label {
  padding-right: 1.1vw;
}

.door {
  width: 9%;
}
.lock-label {
  margin-left: 2.5vw;
}

.lock {
  width: 7%;
}

.hide{
  display: none;
}

@media only screen and (max-width: 1360px) {

.event-desc{
  width:85%;
}
.my-12{
  flex-direction: column;
}
textarea{
  height:5vw;
}

.hide{
  display: inline;
 
}

.hide-on-small{
  display: none;
}

.event-desc{
  margin-left:30px;
}
}

@media only screen and (max-width: 750px) {
ul > li{
  padding-top:30px;
}
}
@media only screen and (max-width: 650px) {
.hide{
  display: flex;
  flex-direction: column;
  
}
.event-desc{
  padding-bottom: 100px;
}

.detailedImg{
  width:50px;
}
}

@media only screen and (max-width: 500px) {
.event-desc{
  width:75vw;
}

}
</style>
