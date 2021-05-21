<template>
  <div class="myCreated-Events-container">

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
      myEvents: [],
    }
  },
  components: {
    EventItem,
  },

  computed: {
     events(){
       return this.$store.state.events
     },
     currEvent() {
      return this.$store.state.specEvent;
    },
    id() {
      return this.$route.params.id;
    },
  },

  methods: {
    async filterEvents() {
      if(this.events === this.currEvent.hostId)
    }
  }


}
</script>

<style scoped>

</style>