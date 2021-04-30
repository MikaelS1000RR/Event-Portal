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
    deleteSuccess: false

    
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

    setCurrLoggedInUser(state, user) {
      state.currLoggedInUser = user;
    },

    setCreatedEvent(state, event) {
      state.createdEvent = event;
      console.log("Event is set", event);
    },

    setDeleteSuccess(state) {
      console.log('setting success in commit');
      state.deleteSuccess = true;
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
    
          console.log("date and time in event is", res.data.endDateTime);
          store.dispatch("fetchSpecUser", res.data.hostId)
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
    },

    fetchWhoAmI(store) {
      axios
        .post("/whoami")
        .then((res) => {
          if (res.data.email !== null) {
             console.log(res.data);
          store.state.commit("setCurrLoggedInUser", res.data);
          }
          else {
            console.log('user is not logged in');
            console.log(store.state.currLoggedInUser);
          }
         
        })
        .catch((err) => {
          console.log(err.response);
        });
      
      
      
    },
    
    async deleteEvent({commit }, id) {
      console.log('in process deleting event');
        await axios
          .delete("/events/" + id)
          .then((res) => {
              
            console.log(res.data);
           commit("setDeleteSuccess");
            
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
