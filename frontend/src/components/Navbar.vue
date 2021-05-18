<template>
  <div class="navbar-wrapper">
    <v-dialog v-model="dialogWrongKey" hide-overlay width="300">
      <v-card color="primary" dark>
        <v-card-text>
          Wrong key
        </v-card-text>
      </v-card>
    </v-dialog>

    <v-navigation-drawer v-model="drawer" absolute temporary dark>
      <v-divider></v-divider>

      <v-list dense>
        <v-list-item>
          <v-list-item-content>
            <v-list-item-title class="user-name"
              >Welcome, {{ getName }}</v-list-item-title
            >
          </v-list-item-content>
        </v-list-item>

        <v-list-item link @click="$router.push('/my-events')">
          <v-list-item-icon>
            <v-icon>mdi-view-dashboard</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>My events</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link @click="$router.push('/joined-events')">
          <v-list-item-icon>
            <v-icon>mdi-calendar-star</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>Joined events</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link @click="$router.push('/create-event')">
          <v-list-item-icon>
            <v-icon>mdi-plus</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>Add event</v-list-item-title>
          </v-list-item-content>
        </v-list-item>

        <v-list-item link @click="invite = !invite">
          <v-list-item-icon>
            <v-icon>mdi-key</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title class="invite-key"
              >Join internal event</v-list-item-title
            >
          </v-list-item-content>
        </v-list-item>

        <v-list-item v-show="invite" v-on:keyup.enter="getInternalEvent">
          <input
            type="text"
            placeholder="Paste invite key"
            class="key-input"
            v-model="inviteKey"
          />
        </v-list-item>

        <v-list-item link @click="logout">
          <v-list-item-icon>
            <v-icon>mdi-logout</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>Log out</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-toolbar color="black" dark fixed app>
      <div class="logo hide">
        <img
          class="logoImg"
          src="../assets/Geshdo-logo.png"
          @click="homeRedirect"
        />
      </div>
      <v-spacer></v-spacer>
      <div v-show="loggedIn" class="hamburger">
        <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      </div>
      <div class="login-navbar" v-show="!loggedIn">
        <button class="login btn" @click="login">Log in</button>
      </div>
    </v-toolbar>
  </div>
</template>

<script>
import { auth } from "/config/auth.js";

export default {
  data() {
    return {
      drawer: null,
      items: [
        { title: "Home", icon: "mdi-view-dashboard" },
        { title: "About", icon: "mdi-forum" },
      ],
      invite: false,
      inviteKey: "",
      dialogWrongKey: false,
    };
  },

  methods: {
    homeRedirect() {
      this.$router.push("/");
    },

    login() {
      auth.loginRedirect();
      console.log(auth.getAccount);
    },

    logout() {
      auth.logout();
    },
    getInternalEvent() {
      let internalEvent = this.$store.state.allEvents.filter((x) => {
        return x.id === this.inviteKey;
      });

      console.log(typeof internalEvent);
      console.log(typeof internalEvent[0]);

      if (internalEvent.length !== 0) {
      

        
        this.$router.push("/details/" + this.inviteKey);
        this.$router.go(0);
        
      }

      if (internalEvent.length === 0) {
        this.dialogWrongKey = true;
      }

      this.inviteKey = "";
    },
  },
  computed: {
    loggedIn: {
      get() {
        console.log(auth.getAccount());
        return auth.getAccount() === null ? false : true;
      },
    },

    getName: {
      get() {
        if (this.loggedIn) {
          const userName = auth.getAccount().name;
          this.$store.commit("setAccount", auth.getAccount());
          return userName.substr(0, userName.indexOf(" "));
        } else {
          return "";
        }
      },
    },
  },
  async created() {
    await this.$store.dispatch("fetchEvents");
  },
};
</script>

<style scoped>
.logoImg {
  width: 150px;
  user-select: none;
}

.logo {
  margin-left: 5vw;
  margin-bottom: -1vw;
  display: flex;
  align-items: center;
  justify-content: center;
}

.logoImg:hover {
  cursor: pointer;
}

.v-dialog > .v-card > .v-card__text {
  padding: 2vh 3vw 2vh 3vw;
  display: flex;

  justify-content: center;
}

.v-application .primary {
  background-color: var(--buttonPurpleSecondary) !important;
}

.v-dialog > .v-card > .v-card__title {
  font-size: 1.1em !important;
  font-family: "Montserrat", sans-serif !important;
}

.hamburger,
.login-navbar {
  margin-right: 5vw;
  margin-top: 1vw;
}

.key-input {
  border: 1px solid;
  padding: 3px;
  border-radius: 7px;
}

.v-btn--icon.v-size--default .v-icon,
.v-btn--fab.v-size--default .v-icon {
  font-size: 300% !important;
}

.v-list-item--dense,
.v-list--dense .v-list-item {
  padding-top: 2vh;
  padding-bottom: 2vh;
}

.v-application .black {
  background-color: #1e1e1e !important;
  height: 75px !important;
}

.login-navbar {
  display: flex;
  flex-direction: row;
  gap: 20px;
  align-items: center;
  justify-content: center;
}

.btn {
  background: -webkit-linear-gradient(rgb(153, 53, 219), rgb(226, 126, 196));
  font-size: 28px;

  -webkit-background-clip: text;
  background-clip: text;
  -webkit-text-fill-color: transparent;
}

@media only screen and (max-width: 1000px) {
  .btn {
    font-size: 20px;
  }
}

@media only screen and (max-width: 750px) {
  .v-application .black {
    height: 50px !important;
  }

  .btn {
    font-size: 15px;
  }
  .logo {
    margin: 0px;
  }
  .logoImg {
    width: 80px;
  }
}
</style>
