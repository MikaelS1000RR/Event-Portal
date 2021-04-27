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

    fetchSpecUser(store, id) {
      console.log('id in fetch user is', id);
      axios
        .get("/users/" + id)
        .then((res) => {
          console.log(res.data);
          store.commit("setSpecUser", res.data);
        })
        .catch((err) => {
          console.log(err.response);
        });
    },

    fetchSpecEvent(store, id) {
      axios
        .get("/events/" + id)
        .then((res) => {
          console.log(res.data);
          store.commit("setSpecEvent", res.data);
          store.dispatch("fetchSpecUser", res.data.hostId)
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
