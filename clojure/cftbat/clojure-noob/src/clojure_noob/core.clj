(ns clojure-noob.core
  (:gen-class))

(require '[clojure.string :as str])

(defn -main
  "I don't do a whole lot ... yet."

  []

  (defn matching-part
    [body-part]

    {:name (str/replace (:name body-part) #"^left-" "right-")
     :size (:size body-part)})

  (defn symmetrize-body
    [unsym-body]
    (loop [remaining-body-parts unsym-body final-body-parts []]
      (if (empty? remaining-body-parts)
        final-body-parts
        (let [[part & remaining] remaining-body-parts]
          (recur remaining
                 (into final-body-parts
                       (set[part (matching-part part)])))))))

  (println (symmetrize-body [{:name "head" :size 3}
                             {:name "nose" :size 1}
                             {:name "mouth" :size 1}
                             {:name "eyes" :size 1}
                             {:name "left-arm" :size 5}
                             {:name "left-leg" :size 5}])))

