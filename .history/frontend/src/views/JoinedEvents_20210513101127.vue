<template>
  <div class="joined-events-container">

<div class="event-list" >
      <EventItem v-for="event of filterJoinedEvents" :key="event.id" :event="event" />
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

      async joinedEvents() {


       
         const bob = await this.$store.state.events.filter 
        (event => event.joinedUsers.includes(this.$store.state.account.name));

        console.log(bob);

          return bob;

      }
    },

 async created() {
      

 this.$store.state.('setEvents');

 console.log(this.$store.state.events);

    },

  

  }


</script>

<style scoped>

</style>