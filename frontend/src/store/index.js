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
    myEvent: {}
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

    setMyEvent(state, event) {
      state.myEvent = event;
      console.log('my event has been set', state.myEvent);
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

    createNewEvent(name, location, startDateTime, endDateTime, description, hostId, access) {
     
     /*
      let newEvent = {
        name: "dbdb",
        location: "bdbfdb",
        startDateTime: "2021-04-20T13:31:59.3528866Z",
        endDateTime: "2021-04-20T13:31:59.3528866Z",
        access: "private",
        hostId: "061eb70c-7055-4d07-a584-b3c20cd59d73",
        description: "blah",
      };*/

      console.log(typeof name);
      console.log(JSON.parse(JSON.stringify(name)));
      console.log(typeof location);
      console.log(typeof description);
      console.log(typeof access);

     
    
     /* axios({
        method: "post",
        url: "/events",
        data: {
          name: name,
          description: "Meeting to discuss our business in future",
          access: "public",
          location: "Tokysdvso",
          startDateTime: "2021-04-20T13:31:59.3528866+00:00",
          endDateTime: "2022-04-21T13:31:49.3528866+00:00",
          hostId: "7bcd7cff-1848-4a02-9db9-3d2265e97aba",
        },
      }).then(
        (response) => {
          console.log(response);
        },
        (error) => {
          console.log(error);
        }
      );
      */
   
    }
  },

  modules: {},

 
});
