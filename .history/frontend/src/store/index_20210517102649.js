import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";
import { getToken } from '/config/auth.js'

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    events: [],
    users: [],
    specEvent: "",
    specUser: "",
    createdEvent: {},
    success: false,
    publicAccess: false,
    privateAccess: false,
    internalAccess: false,
    filteredEventsByLetter: [],
    updatedEvent: {},
    accessTypes: [],
    allEvents: [],
    loading: false,
    account: undefined
    
  },
  mutations: {

    set filte

    setEvents(state, events) {
      state.events = events;
    },

    setSpecEvent(state, event) {
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

    setSuccess(state, bool) {
      state.success = bool;
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
   
    },
    setAccessTypes(state, accessTypes) {
      state.accessTypes = accessTypes;
    },

    setAllEvents(state, allEvents) {
      state.allEvents = allEvents;
    },

    setAccount(state, account) {
      state.account = account;
     
    }
  },

  actions: {

    async joinEvent(store) {
      console.log(typeof store.state.account.name);

      await axios
        .post(
          "/addUserToEvent/" + store.state.specEvent.id, [store.state.account.name],
          {
            headers: {
              Authorization: `Bearer ${await getToken()}`,
              "Content-type": "application/json; charset=UTF-8",
            },
          }
        )
        .then((res) => {
          console.log(res.data);
          store.commit("setSuccess", true);
        })
        .catch((err) => {
          console.log(err.response);
        });
    },




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
           Authorization: `Bearer ${await getToken()}`
           }
        })
        .then((response) => {
          console.log(response);
        store.commit("setSuccess", true)
        })
        .catch((err) => {
          console.log(err.response);
        });
    },


    async deleteEvent({ commit }, id) {
      await axios
        .delete("/events/" + id, {
            headers: {
           Authorization: `Bearer ${await getToken()}`
           }
        })
        .then((res) => {
          console.log(res.data);
          commit("setSuccess", true);
        })
        .catch((err) => {
          console.log(err.response);
        });
    },

    async updateEvent(store) {
      await axios
        .put(
          "/events/" + store.state.specEvent.id,
          store.state.updatedEvent,
          {
            headers: {
              Authorization: `Bearer ${await getToken()}`,
              "Content-Type": "application/json",
            },
          }
        )
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
        .post("/login", {
            headers: {
           Authorization: `Bearer ${await getToken()}`
           }
        })
        .then((response) => {
          console.log(response);
          commit("setCurrLoggedInUser", undefined);
        })
        .catch((err) => {
          console.log(err.response);
        });
    },

    async getAccountName({ commit }, account) {
      
      commit("setAccount", account);
    }

  },

  modules: {},

  getters: {
    getAllEvents(state) {
      return state.events;
    },
  },
});
