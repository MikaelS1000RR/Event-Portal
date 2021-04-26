import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    events: [],
    specEvent: "",
    id: "",
    
  },
  mutations: {
    setEvents(state, events) {
      state.events = events;
    },

    setSpecEvent(state, event) {
      state.specEvent = event;
    },
    setId(state, id) {
      state.id = id;
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

    fetchSpecEvent({ state, commit }) {
      axios
        .get("/events/" + state.id)
        .then((res) => {
          console.log(res.data);
          commit("setSpecEvent", res.data);
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
