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

    }
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
          joinedEvents = fi
        }

          return joinedEvents;

      }
    },

    async created() {
      await this.$store.dispatch('fetchEvents');
    }

  


  

  }


</script>

<style scoped>

</style>