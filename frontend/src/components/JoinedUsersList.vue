<template>
  <v-card>
    <v-card-title class="white--text orange darken-4">
      Joined user list

      <v-spacer></v-spacer>
    </v-card-title>

    <v-divider></v-divider>

    <v-virtual-scroll :items="joinedUsers" :item-height="50" height="150">
      <template v-slot:default="{ item }">
        <v-list-item>
          <v-list-item-avatar>
            <v-avatar :color="item.color" size="56" class="white--text">
              {{ item.initials }}
            </v-avatar>
          </v-list-item-avatar>

          <v-list-item-content>
            <v-list-item-title>{{ item.fullName }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>


      </template>
  
    </v-virtual-scroll>
  </v-card>
</template>

<script>
export default {
  //props:['show', 'names', 'surnames'],
  data() {
    return {
      colors: [
        "#2196F3",
        "#90CAF9",
        "#64B5F6",
        "#42A5F5",
        "#1E88E5",
        "#1976D2",
        "#1565C0",
        "#0D47A1",
        "#82B1FF",
        "#448AFF",
        "#2979FF",
        "#2962FF",
      ],
    };
  },

  computed: {
    joinedUsers() {
      const joinedUsers = this.$store.state.specEvent.joinedUsers;
       const joinedGuests = this.$store.state.specEvent.joinedGuests;
      const length = joinedUsers.length + joinedGuests.length

      const names = joinedUsers.map(
        (user) => user.firstName
      ).concat(joinedGuests.map(guest => guest.guestName))

      console.log(names);
      const surnames = joinedUsers.map(
        (user) => user.lastName
      );
      const namesLength = names.length;
      const surnamesLength = surnames.length;
      const colorsLength = this.colors.length;
      let i=-1;
      return Array.from({ length: length }, (k, v) => {
        i++
        const name = names[i];
        const surname = surnames[i];
        if(i <= joinedUsers.length-1)
        {

        return {
          color: this.colors[this.genRandomIndex(colorsLength)],
          fullName: `${name} ${surname}`,
          initials: `${name[0]} ${surname[0]}`,
        }
      }
      else{
         
        return {
          color: this.colors[this.genRandomIndex(colorsLength)],
          fullName: `${name}`,
          initials: `${name[0]}`,
        }
      }
      });
    },

    joinedGuests(){
       const joinedGuests = this.$store.state.specEvent.joinedGuests;
      const length = joinedGuests.length

      const names = joinedGuests.map(
        (guest) => guest.guestName
      );
   
      const namesLength = names.length;
      const colorsLength = this.colors.length;

      return Array.from({ length: length }, (k, v) => {
        const name = names[this.genRandomIndex(namesLength)];

        return {
          color: this.colors[this.genRandomIndex(colorsLength)],
          fullName: `${name}`,
          initials: `${name[0]}`,
        };
      });
    }
  },

  methods: {
    genRandomIndex(length) {
      return Math.ceil(Math.random() * (length - 1));
    },
  },
};
</script>

<style scoped></style>
