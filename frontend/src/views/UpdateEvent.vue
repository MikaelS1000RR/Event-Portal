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
                <div class="help-circle">
                <v-tooltip bottom>
                  <template v-slot:activator="{ on, attrs }">
                    <v-icon v-bind="attrs" v-on="on">
                      mdi-help-circle
                    </v-icon>
                  </template>
                  <div class="help-info">
                    <p>Public events are accessible for anybody, even for unregistered users
                 in comparison to private events which can be seen only by registered users. Internal events
                 on other hand, can not be seen by anybody unless user is registered and has a special link to the event</p>
                  </div>
                  
                </v-tooltip>
                </div>

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
                <div class="save-btn">
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

        <div class="event-desc">
          <div class="description">
            <p>Description</p>
          </div>

          <textarea v-model="description" name="" id="" cols="30" rows="7">
          </textarea>
        </div>
      </v-card>
    </form>
  </div>
</template>

<script>
export default {
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
    };
  },
  methods: {
    async saveChanges() {
      const l = this.loader;
      this[l] = !this[l];

      await new Promise((res) => setTimeout(res, 3000));

      this[l] = false;
      this.loader = null;

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
  width: 50vw;
  grid-auto-rows: 15% 85%;

  padding-top: 2.6vw;
  padding-bottom: 10vh;
}

.v-application .success {
  background-color: var(--buttonPurple) !important;
}

li > span {
  padding: 0 1vw 0 1vw;
}
.help-info{
  max-width:15vw;
  
}
input,
textarea {
  border: 1px solid #000 !important;
  padding: 0.5vw 1vw 0.5vw 1vw;
}

.help-circle{
  padding-right:2vw;
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
</style>
