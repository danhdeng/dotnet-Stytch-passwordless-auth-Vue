d
<script>
export default {
  name: 'Login',
  data: () => {
    return {
      isLoading: false,
      successMessage: '',
      email: '',
    };
  },
  computed: {
    sendMessage() {
      return this.isLoading ? 'sending...' : 'Send Magic Link';
    },
  },
  methods: {
    async sendMagicLink() {
      this.isLoading = true;
      this.successMessage = '';
      try {
        const response = await fetch('http://localhost:8080/createOrLogin', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify({
            email: this.email,
          }),
        });
        this.successMessage = 'Check your Email for a Magic Link to log in!';
      } catch (ex) {
        console.error(ex);
        this.isLoading = false;
      } finally {
        this.isLoading = false;
      }
      console.log('sending Magic Link request');
      this.successMessage = 'Check your Email for a Magic Link to log in!';
      this.isLoading = false;
    },
  },
};
</script>
<template>
  <div class="bg-slate-200 h-screen">
    <div class="h-full">
      <div
        class="flex justify-center items-center flex-wrap h-full g-6 text-gray-800"
      >
        <div class="w-1/3">
          <div class="block bg-white shadow-lg rounded-lg">
            <div class="flex flex-wrap">
              <div class="w-2/3 px-2 py-12">
                <div class="px-12 mx-6">
                  <div class="text-center">
                    <h4 class="text-2xl font-semibold mt-1 mb-12 pb-1">
                      Mindful Gifts
                    </h4>
                  </div>
                  <form @submit.prevent="">
                    <p class="mb-4">Enter your Email to login</p>
                    <div class="mb-4">
                      <input
                        id="magiclinkButton"
                        v-model="email"
                        class="form-control block w-full px-3 py-1.5 text-base font-normal text-gray-700 bg-white bg-clip-padding border border-solid border-gray-300 rounded transition ease-in-out m-0 focus:text-gray-700 focus:bg-white focus:border-blue-50 focus:outline-none"
                        placeholder="e.g. youremail@gmail.com"
                        type="text"
                      />
                    </div>
                    <div>
                      <button
                        v-if="!successMessage"
                        :class="{ disabled: isLoading }"
                        class="bg-indigo-500 text-indigo-100 py-2 px-3 rounded"
                        @click="sendMagicLink"
                      >
                        <span>
                          <span
                            class="white h-2 bg-indigo-500 rounded-full"
                          ></span>
                          <span
                            class="white h-2 bg-indigo-600 rounded-full"
                          ></span>
                          <span
                            class="white h-2 bg-indigo-700 rounded-full"
                          ></span>
                        </span>
                        <span>
                          {{ sendMessage }}
                        </span>
                      </button>
                    </div>
                    <div class="text-emerald-400 py-2">
                      {{ successMessage }}
                    </div>
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
