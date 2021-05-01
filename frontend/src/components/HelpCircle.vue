<template>
  <div class="help-circle">
    <v-tooltip bottom>
      <template v-slot:activator="{ on, attrs }">
        <v-icon v-bind="attrs" v-on="on">
          mdi-help-circle
        </v-icon>
      </template>
      <div class="help-info">
        <p>
          Public events are accessible for anybody, even for unregistered users
          in comparison to private events which can be seen only by registered
          users. Internal events on other hand, can not be seen by anybody
          unless user is registered and has a special link to the event
        </p>
      </div>
    </v-tooltip>
  </div>
</template>

<script>
export default {};
</script>

<style scoped>
.help-circle {
  padding-right: 2vw;
}
.help-info{
  max-width:18vw;
  
}

.mdi-set, .mdi:before{
  font-size:.8em !important;
}
</style>
