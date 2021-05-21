<template>
  <div class="joined-events-container">



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
</template>

<script>
import EventItem from "../components/EventItem.vue";

export default {

 data() {

    return {


    }
  },
  components: {
    EventItem,
  },


    computed: {

       events() {


       
         const joinedEvents = this.$store.state.allEvents.filter 
        (event => event.joinedUsers.includes(this.$store.state.account.name));

        console.log(joinedEvents);

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