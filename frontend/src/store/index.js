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
    createdEvent: {},
    currLoggedInUser: {},
    deleteSuccess: false,
    publicAccess: false,
    privateAccess: false,
    internalAccess: false,
  },
  mutations: {
    setEvents(state, events) {
      state.events = events;
    },
    setUsers(state, users) {
      state.users = users;
    },

    setSpecEvent(state, event) {
      console.log("specific event is set");
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

    setCurrLoggedInUser(state, user) {
      state.currLoggedInUser = user;
    },

    setCreatedEvent(state, event) {
      state.createdEvent = event;
    },

    setDeleteSuccess(state) {
      state.deleteSuccess = true;
    },
    setPublicAccess(state) {
      state.publicAccess = true;
      state.privateAccess = false;
      state.internalAccess = false;
    },
    setPrivateAccess(state) {
      state.privateAccess = true;
      state.publicAccess = false;
      state.internalAccess = false;
    },
    setInternalAccess(state) {
      state.internalAccess = true;
      state.privateAccess = false;
      state.publicAccess = false;
    },
  },

  actions: {
    async fetchEvents({ commit }) {
      await axios
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

    async fetchSpecUser(store, id) {
      console.log("id in fetch user is", id);
      await axios
        .get("/users/" + id)
        .then((res) => {
          console.log(res.data);
          store.commit("setSpecUser", res.data);
        })
        .catch((err) => {
          console.log(err.response);
        });
    },

    async fetchSpecEvent(store, id) {
      await axios
        .get("/events/" + id)
        .then((res) => {
          console.log(res.data);
          store.commit("setSpecEvent", res.data);

          console.log("date and time in event is", res.data.endDateTime);
          store.dispatch("fetchSpecUser", res.data.hostId);
        })
        .catch((err) => {
          console.log(err.response);
        });
    },

    async createNewEvent(store) {
      await axios.post("/events", store.state.createdEvent).then((response) => {
        this.isSuccess = true;
        console.log(response);
      });
    },

    async fetchWhoAmI(store) {
      await axios
        .post("/whoami")
        .then((res) => {
          if (res.data.email !== null) {
            console.log(res.data);
            store.state.commit("setCurrLoggedInUser", res.data);
          } else {
            console.log("user is not logged in");
            console.log(store.state.currLoggedInUser);
          }
        })
        .catch((err) => {
          console.log(err.response);
        });
    },

    async deleteEvent({ commit }, id) {
      console.log("in process deleting event");
      await axios
        .delete("/events/" + id)
        .then((res) => {
          console.log(res.data);
          commit("setDeleteSuccess");
        })
        .catch((err) => {
          console.log(err.response);
        });
    },
  },

  modules: {},

  getters: {
    getAllEvents(state) {
      return state.events;
    },
  },
});
