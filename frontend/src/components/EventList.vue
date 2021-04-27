<template>
  <div class="wrapper">
    <div class="event-list">
      <EventItem v-for="event of events" :key="event.id" :event="event" />
    </div>
  </div>
</template>

<script>
import EventItem from "./EventItem.vue";
export default {
  components: {
    EventItem,
  },
  computed: {
    events() {
      return this.$store.state.events;
    },
  },
  created() {
    this.$store.dispatch("fetchEvents");
  },
};
</script>

<style scoped>
.wrapper {
  width: 100%;

  display: flex;
  justify-content: center;
  align-items: center;
}

.event-list {
  width: 95%;
  padding-top: 3vw;
  display: grid;
  grid-template-columns: repeat(3, 1fr);

  justify-content: center;

  position: relative;
}
</style>
