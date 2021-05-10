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
    createdEvent: {},
    //joinedUsers: {},
    currLoggedInUser: {},
    deleteSuccess: false,
    publicAccess: false,
    privateAccess: false,
    internalAccess: false,
    updatedEvent: {},
    accessTypes: [],
    allEvents: [],
    loading: false,
    
  },
  mutations: {
    setEvents(state, events) {
      state.events = events;
    },

    setSpecEvent(state, event) {
      console.log("specific event is set");
      state.specEvent = event;
    },
    setSpecUser(state, user) {
      state.specUser = user;
    },

    setCurrLoggedInUser(state, user) {
      state.currLoggedInUser = user;
       console.log("curr logged in user in state is",state.currLoggedInUser);
    },

    setCreatedEvent(state, event) {
      state.createdEvent = event;
      console.log("in process of setting commit", state.createdEvent);
    },

    setJoinedUser(state, user) {
      state.joinedUsers = user;
      console.log("User is joining", state.joinedUsers);
    },

    setDeleteSuccess(state) {
      state.deleteSuccess = true;
    },

    setPublicAccess(state) {
      console.log("setting public");
      state.publicAccess = true;
      state.privateAccess = false;
      state.internalAccess = false;
    },
    setPrivateAccess(state) {
      console.log("setting private");
      state.privateAccess = true;
      state.publicAccess = false;
      state.internalAccess = false;
    },
    setInternalAccess(state) {
      console.log("setting internal");
      state.internalAccess = true;
      state.privateAccess = false;
      state.publicAccess = false;
    },

    setUpdatedEvent(state, event) {
      state.updatedEvent = event;
      console.log("updated event in store is", state.updatedEvent);
    },
    setAccessTypes(state, accessTypes) {
      state.accessTypes = accessTypes;
    },

    setAllEvents(state, allEvents) {
      state.allEvents = allEvents;
    },
  },

  actions: {
    async fetchEvents({ commit }) {
      await axios
        .get("/events")
        .then((res) => {
          console.log(res.data);
          commit("setAllEvents", res.data);
        })

        .catch((err) => {
          console.log(err.response);
        });
    },

    async fetchSpecUser(store, id) {
      store.state.loading = true;
      console.log("id in fetch user is", id);
      await axios
        .get("/users/" + id)
        .then((res) => {
          console.log(res.data);
          store.commit("setSpecUser", res.data);
        })
        .catch((err) => {
          console.log(err.response);
        })
        .finally(() => (store.state.loading = false));
    },

    async fetchSpecEvent(store, id) {
      store.state.loading = true;
      console.log("loading in store is", store.state.loading);
      await axios
        .get("/events/" + id)
        .then((res) => {
          console.log(res.data);
          store.commit("setSpecEvent", res.data);

          if (res.data.access === "private") {
            store.commit("setPrivateAccess");
          } else if (res.data.access === "public") {
            store.commit("setPublicAccess");
          } else if (res.data.access === "internal") {
            store.commit("setInternalAccess");
          }
          store.dispatch("fetchSpecUser", res.data.hostId);
        })
        .catch((err) => {
          console.log(err.response);
        })
        .finally(() => (store.state.loading = false));
    },

    async createNewEvent(store) {
      await axios
        .post("/events", store.state.createdEvent, {
          headers: {
            Authorization: 'Bearer ' + localStorage.getItem('token')
          }
        })
        .then((response) => {
          console.log(response);
        })
        .catch((err) => {
          console.log(err.response);
        });
    },


    // ??? Check later
    async joinNewEvent(store) {
      await axios
        .post("/users", store.state.joinedUsers)
        .then((response) => {
          console.log(response);
        })
        .catch((err) => {
          console.log(err.response);
        });
    },

    async fetchWhoAmI({commit}) {
      await axios
        .post("/whoami")
        .then((res) => {
          if (res.data.email !== null) {
            console.log(res.data);
            commit("setCurrLoggedInUser", res.data);
          } else {
            console.log("user is not logged in");
          }
        })
        .catch((err) => {
          console.log(err.response);
        });
    },

    async deleteEvent({ commit }, id) {
      await axios
        .delete("/events/" + id, headers {
            Authorization: 'Bearer ' + localStorage.getItem('token')
          })
         
        .then((res) => {
          console.log(res.data);
          commit("setDeleteSuccess");
        })
        .catch((err) => {
          console.log(err.response);
        });
    },

    async updateEvent(store) {
      await axios
        .put("/events/" + store.state.specEvent.id, store.state.updatedEvent)
        .then((res) => {
          console.log(res.data);
        })
        .catch((err) => {
          console.log(err.response);
        });
    },

    async fetchFilteredEvents({commit }, accessTypes) {
      await axios
        .post("/filter-events", accessTypes)
        .then((res) => {
          console.log(res.data);
         commit("setEvents", res.data);
        })
        .catch((err) => {
          console.log(err.response);
        });
    },

    async guestJoinEvent(store, guestName) {
      await axios
        .post("/addGuestToEvent/" + store.state.specEvent.id, [guestName])
        .then((response) => {
          console.log(response);
        })
        .catch((err) => {
          console.log(err.response);
        });
    },

    async login({commit}, loginCredentials) {
      await axios
        .post("/login", loginCredentials)
        .then((response) => {
          console.log(response);
          commit("setCurrLoggedInUser", response.data);
          localStorage.setItem('token', response.data.token)
        })
        .catch((err) => {
          console.log(err.response);
        });
    },

    async logout({ commit }) {
      await axios
        .post("/login")
        .then((response) => {
          console.log(response);
          commit("setCurrLoggedInUser", undefined);
        })
        .catch((err) => {
          console.log(err.response);
        });
    }
  },

  modules: {},

  getters: {
    getAllEvents(state) {
      return state.events;
    },
  },
});
