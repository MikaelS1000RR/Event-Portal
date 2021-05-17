<template>
 <div class="searchbar">

  <div class="container">

    <div>

        <input
        class="inp"
          type="text"
          placeholder="Search events... 🔍"
          v-model="searchQuery"
        />
      </div>

      <div class="event-list">
        <EventItem v-for="event of events" :key="event.id" :event="event" />
      </div>

    </div>

  </div>
</template>

<script>
import EventItem from "../components/EventItem.vue";

export default {

 data() {

    return {

      searchQuery: "",

    };
  },
  components: {
    EventItem,
  },


    computed: {

       events() {
        let joinedEvents = this.$store.state.allEvents.filter 
        (event => event.joinedUsers.includes(this.$store.state.account.name));

            console.log(joinedEvents);

             if(this.searchQuery !== "") {
             joinedEvents = joinedEvents.filter((event) =>
             event.name.toLowerCase().includes(this.searchQuery.toLowerCase())
             );

            console.log(joinedEvents);
        }

          return joinedEvents;

      },
    },

    async created() {
      await this.$store.dispatch('fetchEvents');


    }  

  }


</script>

<style scoped>


.container {
  height: 100%;
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
}



input[type=text] {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  box-sizing: border-box;
  border: 3px solid #ccc;
  border-radius: 10px;
  -webkit-transition: 0.4s;
  transition: 0.4s;
  outline: none;
  color: whitesmoke;
}

input[type=text]:focus {
  border: 3px solid rgb(98, 65, 177);
} 

</style>