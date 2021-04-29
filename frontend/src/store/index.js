import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    events: [],
    users: [],
    specEvent: "",
    specUser: "",
    eventId: "",
    userId: "",
    errorMessage: null,
    createdEvent: {}
    
  },
  mutations: {
    setEvents(state, events) {
      state.events = events;
    },
    setUsers(state, users) {
      state.users = users;
    },

    setSpecEvent(state, event) {
      state.specEvent = event;
    },
    setSpecUser(state, user) {
      state.specUser = user;
    },
    setEventId(state, id) {
      state.eventId = id;
    },
    setUserId(state, id) {
      state.userId = id;
    },

    setCreatedEvent(state, event) {
      state.createdEvent = event;
      console.log("Event is set", event);
    }
  },

  actions: {
    fetchEvents({ commit }) {
      axios
        .get("/events")
        .then((res) => {
          console.log(res.data);
          commit("setEvents", res.data);
        })

        .catch((err) => {
          console.log(err.response);
        });
    },

  

    fetchUsers({ commit }) {
      axios
        .get("/users")
        .then((res) => {
          console.log(res.data);
          commit("setUsers", res.data);
        })

        .catch((err) => {
          console.log(err.response);
        });
    },

    fetchSpecEvent({ state, commit }) {
      axios
        .get("/events/" + state.eventId)
        .then((res) => {
          console.log(res.data);
          commit("setSpecEvent", res.data);
        })
        .catch((err) => {
          console.log(err.response);
        });
    },

    fetchSpecUser({ state, commit }) {
      axios
        .get("/users/" + state.userId)
        .then((res) => {
          console.log(res.data);
          commit("setSpecUser", res.data);
        })
        .catch((err) => {
          console.log(err.response);
        });
    },

    createNewEvent(store) {
      axios.post('/events',
        store.state.createdEvent, 
      ).then(response => {
        this.isSuccess = true;
        console.log(response);
      });
    }

  /*  createNewEvent() {
      const event = { name: "New Event test" };
      axios.post("https://geshdo-events-dev-default-rtdb.europe-west1.firebasedatabase.app/events", event)
        .then(response => this.eventId = response.data.id)
        .catch(error => {
          this.errorMessage = error.message;
          console.error("There was en error!", error);
        });
      }*/
    
  },

  modules: {},

  getters: {
    getAllEvents(state) {
      return state.events;
    },
  },
});
