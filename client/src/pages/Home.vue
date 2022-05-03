<script setup lang="ts">
// This starter template is using Vue 3 <script setup> SFCs
// Check out https://vuejs.org/api/sfc-script-setup.html#script-setup
import { store } from '../store/store';
import router from '../router';

export default {
  name: 'Home',
  methods: {
    async signOut() {
      localStorage.removeItem('sessionToken');
      await router.push('/login');
    },
    getImage(imageUrl: string) {
      return new URL(`../images/${imageUrl}`, import.meta.url).href;
    },
  },
  computed: {
    userEmails() {
      return store.state.emails;
    },
  },
  data: () => {
    return {
      products: [
        { id: 1, name: 'Potted Plant', price: 16.0, imageUrl: 'plant.png' },
        { id: 2, name: 'Bird House', price: 18.0, imageUrl: 'birdhouse.png' },
        { id: 3, name: 'Wind Chimes', price: 24.0, imageUrl: 'chimes.png' },
        { id: 4, name: 'Incense', price: 8.0, imageUrl: 'incense.png' },
        { id: 5, name: 'Flower', price: 12.0, imageUrl: 'flower.png' },
        { id: 6, name: 'Card', price: 4.0, imageUrl: 'card.png' },
        { id: 7, name: 'Bell', price: 12.0, imageUrl: 'bell.png' },
        { id: 8, name: 'Pottery', price: 40.0, imageUrl: 'pottery.png' },
        { id: 9, name: 'Watch', price: 100, imageUrl: 'watch.png' },
        {
          id: 10,
          name: 'Baseball Bat',
          price: 59.9,
          imageUrl: 'baseballbat.png',
        },
      ],
    };
  },
};
</script>
<template>
  <div class="bg-slate-200 h-screen">
    <div class="h-full">
      <div
        class="flex justify-center items-center flex-wrap h-full text-gray-800"
      >
        <div class="w-10/12">
          <div class="block bg-white shadow-lg rounded-lg p-12">
            <div class="flex justify-between">
              <div>
                <h1>Mindful Gifts</h1>
                <div>
                  <span v-for="email in userEmails" v-bind:key="email">
                    {{ email.email }}
                  </span>
                </div>
              </div>
              <div>
                <button
                  class="bg-indigo-500 text-indigo-100 py-2 px-3 rounded"
                  @click="signOut"
                >
                  Sign Out
                </button>
              </div>
            </div>
            <div class="flex mt-12 w-full">
              <div class="flex flex-wrap">
                <div
                  v-for="product in products"
                  class="mb-4"
                  v-bind:key="product"
                >
                  <div
                    class="w-72 h-72 bg-slate-300 space-x-2 mx-1 my-1 bg-center"
                    :style="{
                      backgroundImage: `url(${getImage(product.imageUrl)})`,
                    }"
                  ></div>
                  <div>
                    <span class="font-bold mbb-2">{{ product.name }}</span>
                    <span class="text-slate-400"
                      >{{ product.price }} tokens</span
                    >
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
